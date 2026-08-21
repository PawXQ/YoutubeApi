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
    internal class CommentThread : ICommentThread
    {
        IHttpRequest HttpRequest { get; set; }

        public string URL => "commentThreads";

        public CommentThread(IHttpRequest httpRequest)
        {
            HttpRequest = httpRequest;
        }

        public Task<AddVideoCommentThread> AddVideoCommentThreadAsync(string channelId, string videoId, string comment)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
            };

            var input = new
            {
                snippet = new
                {
                    channelId,
                    videoId
                },
                topLevelComment = new
                {
                    snippet = new
                    {
                        textOriginal = comment,
                    }
                }
            };

            return HttpRequest.PostAsync<AddVideoCommentThread>(URL, input, urlParam);
        }

        public Task<GetVideoCommentThread> GetVideoCommentThreadAsync(string videoId)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
                { "videoId", "videoId" },
            };

            return HttpRequest.GetAsync<GetVideoCommentThread>(URL, urlParam);
        }
    }
}
