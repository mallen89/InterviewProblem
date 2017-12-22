using Newtonsoft.Json;
using System;

namespace InterviewProblem
{
    public class TripUploadData
    {

        [JsonProperty("accountId")]
        public int accountId { get; set; }

        [JsonProperty("channel")]
        public string channel { get; set; }

        [JsonProperty("serialNumber")]
        public string serialNumber { get; set; }

        [JsonProperty("timestamp")]
        public DateTime timestamp { get; set; }

        [JsonProperty("data")]
        public double data { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("createdAt")]
        public object createdAt { get; set; }

        [JsonProperty("createdBy")]
        public object createdBy { get; set; }

        [JsonProperty("modifiedAt")]
        public object modifiedAt { get; set; }

        [JsonProperty("modifiedBy")]
        public object modifiedBy { get; set; }
    }
}
