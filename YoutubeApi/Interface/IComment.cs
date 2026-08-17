using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Model;

namespace YoutubeApi.Interface
{
    internal interface IComment : IBaseApi
    {
        //17. GetCommentListResponseAsync
        Task<GetCommentListResponse> GetCommentListResponseAsync(string parentId);

        //19. DeleteComment
        Task<DeleteResult> DeleteCommentAsync(string commentId);

        //20. ModifyComment
        Task<ModefiyComment> ModefiyCommentAsync(string channelId, string commentId, string comment);
    }
}
