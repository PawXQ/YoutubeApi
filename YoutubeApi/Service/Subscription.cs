using HttpUtility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Interface;
using YoutubeApi.Model;

namespace YoutubeApi.Service
{
    internal class Subscription : ISubscription
    {
        IHttpRequest HttpRequest { get; set; }

        public string URL => "subscriptions";

        public Subscription(IHttpRequest httpRequest)
        {
            HttpRequest = httpRequest;
        }

        public Task<SubscriptionChannel> SubscriptionChannelAsync(string channelId)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
            };

            var input = new
            {
                resourceId = new
                {
                    kind = "youtube#subscription",
                    channelId
                }
            };

            return HttpRequest.PostAsync<SubscriptionChannel>(URL, input, urlParam);
        }

        public async Task<DeleteResult> UnScriptionChannelAsync(string id)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "id", id },
            };

            HttpResponseMessage response = await HttpRequest.DeleteAsync(URL, urlParam);

            return new DeleteResult
            {
                IsSuccess = response.IsSuccessStatusCode,
                StatusCode = (int)response.StatusCode,
                Message = response.ReasonPhrase.ToString(),
            };
        }
    }
}
