using System.Net;
using Newtonsoft.Json;

namespace CK.Tutorial.GraphQlApi.Common.Model
{
    public class CustomResultData
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public bool IsError => (ErrorMessage != null);

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorDetailMessage { get; set; }
        
        public HttpStatusCode StatusCode { get; set; }

        public object Data { get; set; }

    }
}