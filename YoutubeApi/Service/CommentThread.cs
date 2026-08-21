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
            throw new NotImplementedException();
        }

        public Task<GetVideoCommentThread> GetVideoCommentThreadAsync(string videoId)
        {
            throw new NotImplementedException();
        }
    }
}
