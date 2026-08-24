using HttpUtility.Interface;
using HttpUtility.Model;
using HttpUtility.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Enum;
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

        public Task<ResponseResult<GetUnLikeVideo>> GetUnLikeVideosAsync()
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
                { "myRating", "dislike" }
            };

            return HttpRequest.GetAsync<GetUnLikeVideo>(URL, urlParam);
        }

        public Task<ResponseResult<GetVideoInfo>> GetVideoInfoAsync(string id)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "id,snippet,statistics,status,contentDetails" },
                { "id", id }
            };

            return HttpRequest.GetAsync<GetVideoInfo>(URL, urlParam);
        }

        public Task<ResponseResult<HttpResponseMessage>> VideoRanting(string id, VideoRating videoRanting)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "id", id },
                { "rating", videoRanting.ToString() }
            };

            return HttpRequest.PostAsync<HttpResponseMessage>(URL, urlParam: urlParam);
        }

        public Task<ResponseResult<ModifyVideoInfo>> ModifyVideoInfoAsync(string id, string title, string categoryId = "22")
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
            };

            var input = new
            {
                id,
                snippet = new
                {
                    title,
                    categoryId
                }
            };

            return HttpRequest.PutAsync<ModifyVideoInfo>(URL, input, urlParam);
        }

        public Task<ResponseResult> DeleteVideoAsync(string id)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "id", id },
            };

            return HttpRequest.DeleteAsync(URL, urlParam);
        }

        public Task<ResponseResult<GetLikeVideo>> GetLikeVideosAsync()
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
                { "myRating", "like" }
            };

            return HttpRequest.GetAsync<GetLikeVideo>(URL, urlParam);
        }
    }
}
