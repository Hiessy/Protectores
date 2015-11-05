using System;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using GoogleEntities;

namespace GoogleApiRequest
{
    public class GoogleConnector
    {
        public const string GOOGLE_MAP_API_BASEURL = "https://maps.googleapis.com/maps/api/";

        public static string CreateGeocodeRequest(string addressNumber, string streetName, string cityName, string countryName)
        {
            string baseUrl = "geocode/json?";
            string address = "address=" + addressNumber + "+" + streetName + ",+" + cityName + ",+" + countryName;
            string requestUrl = GOOGLE_MAP_API_BASEURL + baseUrl + address;
            Console.WriteLine(requestUrl);
            return (requestUrl);
        }

        public static GeocodeResponse MakeRequest(string addressNumber, string streetName, string cityName, string countryName)
        {
            string requestUrl = CreateGeocodeRequest(addressNumber, streetName, cityName, countryName);
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(GeocodeResponse));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    GeocodeResponse jsonResponse = objResponse as GeocodeResponse;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
