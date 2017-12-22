using Newtonsoft.Json;

namespace InterviewProblem
{
    public class TripSetting
    {
        [JsonProperty("accountId")]
        public int accountId { get; set; }

        [JsonProperty("tripId")]
        public object tripId { get; set; }

        [JsonProperty("dataType")]
        public string dataType { get; set; }

        [JsonProperty("min")]
        public int min { get; set; }

        [JsonProperty("max")]
        public double max { get; set; }

        [JsonProperty("channelName")]
        public string channelName { get; set; }

        [JsonProperty("alias")]
        public object alias { get; set; }
    }

}
