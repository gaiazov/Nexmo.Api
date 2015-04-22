using Newtonsoft.Json;
using System.Dynamic;

namespace Nexmo.Model
{
    public class Message
    {
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Alert
    {
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("status-report-req")]
        public bool StatusReportReq { get; set; }
        [JsonProperty("template")]
        public int Template { get; set; }

        public dynamic TemplateFields { get; set; }

        public Alert()
        {
            this.TemplateFields = new ExpandoObject();
        }
    }
}

