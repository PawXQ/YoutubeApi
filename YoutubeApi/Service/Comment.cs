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
    internal class Comment : IComment
    {
        IHttpRequest HttpRequest { get; set; }

        public string URL => "comments";

        public Comment(IHttpRequest httpRequest)
        {
            HttpRequest = httpRequest;
        }

        public async Task<DeleteResult> DeleteCommentAsync(string commentId)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "commentId", commentId },
            };

            HttpResponseMessage response = await HttpRequest.DeleteAsync(URL, urlParam);

            return new DeleteResult
            {
                IsSuccess = response.IsSuccessStatusCode,
                StatusCode = (int)response.StatusCode,
                Message = response.ReasonPhrase.ToString(),
            };
        }

        public Task<GetCommentListResponse> GetCommentListResponseAsync(string parentId)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
                { "parentId", parentId }
            };

            return HttpRequest.GetAsync<GetCommentListResponse>(URL, urlParam);
        }

        public Task<ModefiyComment> ModefiyCommentAsync(string channelId, string commentId, string comment)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
            };

            var input = new
            {
                kind = "youtube#comment",
                id = "commentId",
                snippet = new
                {
                    channelId,
                    textOriginal = comment,
                }
            };

            return HttpRequest.PutAsync<ModefiyComment>(URL, input, urlParam);
        }
    }
}
