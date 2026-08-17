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
        public string URL => throw new NotImplementedException();

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
