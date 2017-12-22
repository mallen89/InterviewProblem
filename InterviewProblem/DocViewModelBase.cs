using Newtonsoft.Json;
using System;

namespace InterviewProblem
{
    public abstract class DocViewModelBase
    {
        /// <summary>
        /// Database id field for object
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Audit column recording time object created in database
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Audit column recording the name of the user who saved the object
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Audit column recording time object modified in database 
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Audit column recording the name of the user who modified the object
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Method to stringify the object as a JSON string
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}