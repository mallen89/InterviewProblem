using Newtonsoft.Json;
using System;

namespace InterviewProblem
{
    public class TripUploadEvent
    {

        public TripUploadEvent()
        {

        }

        public TripUploadEvent(int accountId, object serialNumber, string channel, int eventType, DateTime timestamp, string alarmData, object comments, object commentThread, object dataType, object unitLabel, int id, object createdAt, object createdBy, object modifiedAt, object modifiedBy)
        {
            this.accountId = accountId;
            this.alarmData = alarmData;
            this.channel = channel;
            this.comments = comments;
            this.commentThread = commentThread;
            this.createdAt = createdAt;
            this.createdBy = createdBy;
            this.dataType = dataType;
            this.eventType = eventType;
            this.id = id;
            this.modifiedAt = modifiedAt;
            this.modifiedBy = modifiedBy;
            this.serialNumber = serialNumber;
            this.timestamp = timestamp;
            this.unitLabel = unitLabel;
        }

        [JsonProperty("accountId")]
        public int accountId { get; set; }

        [JsonProperty("serialNumber")]
        public object serialNumber { get; set; }

        [JsonProperty("channel")]
        public string channel { get; set; }

        [JsonProperty("eventType")]
        public int eventType { get; set; }

        [JsonProperty("timestamp")]
        public DateTime timestamp { get; set; }

        [JsonProperty("alarmData")]
        public string alarmData { get; set; }

        [JsonProperty("comments")]
        public object comments { get; set; }

        [JsonProperty("commentThread")]
        public object commentThread { get; set; }

        [JsonProperty("dataType")]
        public object dataType { get; set; }

        [JsonProperty("unitLabel")]
        public object unitLabel { get; set; }

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
