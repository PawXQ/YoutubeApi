using HttpUtility.Interface;
using HttpUtility.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Interface;
using YoutubeApi.Model;

namespace YoutubeApi.Service
{
    internal class Channels : IChannels
    {
        IHttpRequest HttpRequest { get; set; }

        public string URL => "channels";

        public Channels(IHttpRequest httpRequest)
        {
            HttpRequest = httpRequest;
        }


        public Task<ResponseResult<GetChannelsInfo>> GetChannelsInfoAsync(string channelsId)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
                { "id", channelsId },
            };

            return HttpRequest.GetAsync<GetChannelsInfo>(URL, urlParam);
        }
    }
}
