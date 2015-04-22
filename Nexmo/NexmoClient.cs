using Newtonsoft.Json.Linq;
using Nexmo.Model;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Nexmo
{
    public class NexmoClient
    {
        public string ApiKey { get; private set; }
        public string ApiSecret { get; private set; }

        private static string ENDPOINT_URL = "https://rest.nexmo.com/";

        private readonly RestClient _client;

        public NexmoClient(string apiKey, string apiSecret, int timeout = 0)
        {
            ApiKey = apiKey;
            ApiSecret = apiSecret;

            _client = new RestClient(ENDPOINT_URL);

            _client.AddHandler("application/json", new Utils.DynamicJsonDeserializer());
            _client.Timeout = timeout;

        }

        public Task<Response> SendSMSAsync(Message message)
        {
            Task<IRestResponse> post = PostAsync("sms/json", message);

            return post.ContinueWith(p => Utils.JSON.Parse<Response>(p.Result.Content), TaskContinuationOptions.ExecuteSynchronously);
        }

        public Task<Response> SendAlertAsync(Alert alert)
        {
            JObject alertWithFields = JObject.FromObject(alert);

            alertWithFields.Remove("TemplateFields");

            foreach (var x in alert.TemplateFields)
            {
                alertWithFields[x.Key] = x.Value;
            }
            Task<IRestResponse> post = PostAsync("sc/us/alert/json", alertWithFields);

            return post.ContinueWith(p => Utils.JSON.Parse<Response>(p.Result.Content), TaskContinuationOptions.ExecuteSynchronously);
        }

        #region Private Methods
        private Task<IRestResponse> PostAsync(string path, object data)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            var request = new RestRequest(path, Method.POST) { RequestFormat = DataFormat.Json };

            request.AddParameter("api_key", ApiKey);
            request.AddParameter("api_secret", ApiSecret);

            JObject values = data is JObject ? data as JObject : JObject.FromObject(data);
            foreach (var x in values)
            {
                request.AddParameter(x.Key, x.Value);
            }

            _client.ExecuteAsync(request, (response) =>
            {
                // if internal server error, then mandrill should return a custom error.
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    ///var error = JSON.Parse<ErrorResponse>(response.Content);
                    var ex = new Exception(string.Format("Post failed {0}", path));
                    tcs.SetException(ex);
                }
                else if (response.StatusCode != HttpStatusCode.OK)
                {
                    // used to throw errors not returned from the server, such as no response, etc.
                    tcs.SetException(response.ErrorException);
                }
                else
                {
                    tcs.SetResult(response);
                }
            });

            return tcs.Task;
        }
        #endregion
    }
}