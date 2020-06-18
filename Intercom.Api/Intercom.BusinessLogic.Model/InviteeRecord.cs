using Newtonsoft.Json;

namespace Intercom.BusinessLogic.Model
{
    public class InviteeRecord 
    {
        [JsonProperty(PropertyName = "DistanceFromOfficeLocation")]
        public double DistanceFromOfficeLocation { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}

