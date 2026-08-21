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
    internal class Comment : IComment
    {
        IHttpRequest HttpRequest { get; set; }

        public string URL => "comments";

        public Comment(IHttpRequest httpRequest)
        {
            HttpRequest = httpRequest;
        }

        public Task<DeleteResult> DeleteCommentAsync(string commentId)
        {
            throw new NotImplementedException();
        }

        public Task<GetCommentListResponse> GetCommentListResponseAsync(string parentId)
        {
            throw new NotImplementedException();
        }

        public Task<ModefiyComment> ModefiyCommentAsync(string channelId, string commentId, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
