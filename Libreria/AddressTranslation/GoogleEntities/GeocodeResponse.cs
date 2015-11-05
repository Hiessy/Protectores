using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace GoogleEntities
{
    public class GeocodeResponse
    {
        [DataMember(Name = "results")]
        public ResourceSet[] results { get; set; }
        [DataMember(Name = "status")]
        public string status { get; set; }
    }

    [DataContract]
    public class ResourceSet
    {
        [DataMember(Name = "address_components")]
        public AddressComponents[] addressComponents { get; set; }
        [DataMember(Name = "formatted_address")]
        public string formattedAddress { get; set; }
        [DataMember(Name = "geometry")]
        public Geometry geometry { get; set; }
        [DataMember(Name = "partial_match")]
        public bool partialMatch { get; set; }
        [DataMember(Name = "place_id")]
        public string placeId { get; set; }
        [DataMember(Name = "types")]
        public string[] types { get; set; }
    }

    [DataContract]
    public class AddressComponents
    {
        [DataMember(Name = "long_name")]
        public string longName { get; set; }
        [DataMember(Name = "short_name")]
        public string shortName { get; set; }
        [DataMember(Name = "types")]
        public string[] types { get; set; }
    }

    [DataContract]
    public class Geometry
    {
        [DataMember(Name = "bounds")]
        public CardinalLocations bounds { get; set; }
        [DataMember(Name = "location")]
        public Location location { get; set; }
        [DataMember(Name = "location_type")]
        public string locationType { get; set; }
        [DataMember(Name = "viewport")]
        public CardinalLocations viewport { get; set; }
    }

    [DataContract]
    public class CardinalLocations
    {
        [DataMember(Name = "northeast")]
        public Location northEast { get; set; }
        [DataMember(Name = "southwest")]
        public Location southWest { get; set; }
    }

    [DataContract]
    public class Location
    {
        [DataMember(Name = "lat")]
        public double lat { get; set; }
        [DataMember(Name = "lng")]
        public double lng { get; set; }
    }
}
