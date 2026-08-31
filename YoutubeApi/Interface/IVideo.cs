using HttpUtility.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        Task<ResponseResult<GetVideoInfo>> GetVideoInfoAsync(string id);

        //3. VideoRating
        Task<ResponseResult> VideoRating(string id, VideoRating videoRating);

        //5.1.1 VideoResumableUploadURL
        //Task<ResponseResult<HttpResponseMessage>> VideoResumableUploadURL(string id, VideoRating videoRanting);

        //5.1.2 VideoResumableUpload

        //5.2 VideoSingleUpload
        Task<ResponseResult<VideoSingleUpload>> VideoSingleUploadAsync(FileStream fileStream, string title, string categoryId = "22", string privacyStatus = "private");


        //6. ModifyVideoInfo
        Task<ResponseResult<ModifyVideoInfo>> ModifyVideoInfoAsync(string id, string title, string categoryId = null);

        //7. DeleteVideo
        Task<ResponseResult> DeleteVideoAsync(string id);

        //8. GetLikeVideo
        Task<ResponseResult<GetLikeVideo>> GetLikeVideosAsync();

        //9. GetUnLikeVideo
        Task<ResponseResult<GetUnLikeVideo>> GetUnLikeVideosAsync();
    }
}
