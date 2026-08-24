using HttpUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Model;

namespace YoutubeApi.Interface
{
    internal interface ICommentThread : IBaseApi
    {
        //16. GetVideoCommentThread
        Task<ResponseResult<GetVideoCommentThread>> GetVideoCommentThreadAsync(string videoId);

        //18. AddVideoCommentThread
        Task<ResponseResult<AddVideoCommentThread>> AddVideoCommentThreadAsync(string channelId, string videoId, string comment);
    }
}
