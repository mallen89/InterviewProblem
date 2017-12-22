using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InterviewProblem
{
    public class TripVm : DocViewModelBase
    {

        [JsonProperty("accountId")]
        public int accountId { get; set; }

        [JsonProperty("serialNumber")]
        public string serialNumber { get; set; }

        [JsonProperty("deviceModelId")]
        public int deviceModelId { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("startTime")]
        public DateTime startTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime endTime { get; set; }

        [JsonProperty("loggingInterval")]
        public int loggingInterval { get; set; }

        [JsonProperty("isAlarmEnabled")]
        public bool isAlarmEnabled { get; set; }

        [JsonProperty("isAlarmWrapped")]
        public bool isAlarmWrapped { get; set; }

        [JsonProperty("locationId")]
        public int locationId { get; set; }

        [JsonProperty("tripSettings")]
        public IList<TripSetting> tripSettings { get; set; }

        [JsonProperty("isDeleted")]
        public bool isDeleted { get; set; }

        [JsonProperty("tripUploadData")]
        public IList<TripUploadData> tripUploadData { get; set; }

        [JsonProperty("tripUploadEvents")]
        public IList<TripUploadEvent> tripUploadEvents { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }

        [JsonProperty("createdBy")]
        public string createdBy { get; set; }

        [JsonProperty("modifiedAt")]
        public DateTime modifiedAt { get; set; }

        [JsonProperty("modifiedBy")]
        public string modifiedBy { get; set; }
    }
}
