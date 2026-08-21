using HttpUtility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Interface;
using YoutubeApi.Model;

namespace YoutubeApi.Service
{
    internal class PlayListItem : IPlayListItem
    {
        IHttpRequest HttpRequest { get; set; }

        public string URL => "playlistItems";

        public PlayListItem(IHttpRequest httpRequest)
        {
            HttpRequest = httpRequest;
        }

        public Task<AddVideoItem> AddVideoItemAsync(string playlistId, string videoId)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
            };

            var input = new
            {
                snippet = new
                {
                    playlistId,
                    resourceId = new
                    {
                        kind = "youtube#video",
                        videoId
                    }
                }
            };

            return HttpRequest.PostAsync<AddVideoItem>(URL, input, urlParam);
        }
    }
}
