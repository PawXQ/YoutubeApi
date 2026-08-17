using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Enum;
using YoutubeApi.Model;

namespace YoutubeApi.Interface
{
    internal interface IVideo : IBaseApi
    {
        //2. GetVideoInfo
        Task<GetVideoInfo> GetVideoInfoAsync(string id);

        //3. VideoRating
        Task<HttpResponseMessage> VideoRanting(string id, VideoRating videoRanting);

        //6. ModifyVideoInfo
        Task<ModifyVideoInfo> ModifyVideoInfoAsync(string id, string title, string categoryId = null);

        //7. DeleteVideo
        Task<DeleteResult> DeleteVideoAsync(string id);

        //8. GetLikeVideo
        Task<GetLikeVideo> GetLikeVideosAsync();

        //9. GetUnLikeVideo
        Task<GetUnLikeVideo> GetUnLikeVideosAsync();
    }
}
