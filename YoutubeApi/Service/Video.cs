using HttpUtility.Interface;
using HttpUtility.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Interface;
using YoutubeApi.Model;

namespace YoutubeApi.Service
{
    internal class Video : IVideo
    {
        IHttpRequest HttpRequest { get; set; }

        public string URL => "video";

        public Video(IHttpRequest httpRequest)
        {
            HttpRequest = httpRequest;
        }

        public Task<GetUnLikeVideo> GetUnLikeVideosAsync()
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
                { "myRating", "dislike" }
            };

            return HttpRequest.GetAsync<GetUnLikeVideo>(URL, urlParam);
        }
    }
}
