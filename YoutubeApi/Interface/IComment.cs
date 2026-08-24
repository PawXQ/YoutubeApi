using HttpUtility.Model;
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
        Task<ResponseResult<GetCommentListResponse>> GetCommentListResponseAsync(string parentId);

        //19. DeleteComment
        Task<ResponseResult> DeleteCommentAsync(string commentId);

        //20. ModifyComment
        Task<ResponseResult<ModefiyComment>> ModefiyCommentAsync(string channelId, string commentId, string comment);
    }
}
