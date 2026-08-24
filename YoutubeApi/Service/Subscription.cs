using HttpUtility.Interface;
using HttpUtility.Model;
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

        public Task<ResponseResult<SubscriptionChannel>> SubscriptionChannelAsync(string channelId)
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

        public Task<ResponseResult> UnScriptionChannelAsync(string id)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "id", id },
            };

            return HttpRequest.DeleteAsync(URL, urlParam);
        }
    }
}
