using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class ErrorMessages
    {
        public string Status { get; set; }
      //  [JsonProperty("ErrorCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorCode { get; set; }
      //  [JsonProperty("Error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }
        public string Message { get; set; }

    }

    public class Error
    {
        public string ErrorCode { get; set; }
        public object ErrorDescription { get; set; }

       // [JsonProperty("Message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
      //  [JsonProperty("Status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }
}
