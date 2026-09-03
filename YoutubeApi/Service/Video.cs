using HttpUtility.Interface;
using HttpUtility.Model;
using HttpUtility.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using YoutubeApi.Enum;
using YoutubeApi.Interface;
using YoutubeApi.Model;
using YoutubeApi.Model.HttpContent;

namespace YoutubeApi.Service
{
    internal class Video : IVideo
    {
        IHttpRequest HttpRequest { get; set; }

        public string URL => "videos";

        public Video(IHttpRequest httpRequest)
        {
            HttpRequest = httpRequest;
        }

        public Task<ResponseResult<GetUnLikeVideo>> GetUnLikeVideosAsync()
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
                { "myRating", "dislike" }
            };

            return HttpRequest.GetAsync<GetUnLikeVideo>(URL, urlParam);
        }

        public Task<ResponseResult<GetVideoInfo>> GetVideoInfoAsync(string id)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "id,snippet,statistics,status,contentDetails" },
                { "id", id }
            };

            return HttpRequest.GetAsync<GetVideoInfo>(URL, urlParam);
        }

        public Task<ResponseResult> VideoRatingAsync(string id, VideoRating videoRating)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "id", id },
                { "rating", videoRating.ToString() }
            };

            return HttpRequest.PostAsync($"{URL}/rate", urlParam: urlParam);
        }

        public Task<ResponseResult<ModifyVideoInfo>> ModifyVideoInfoAsync(string id, string title, string categoryId = "22")
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
            };

            var input = new
            {
                id,
                snippet = new
                {
                    title,
                    categoryId
                }
            };

            return HttpRequest.PutAsync<ModifyVideoInfo>(URL, input, urlParam);
        }

        public Task<ResponseResult> DeleteVideoAsync(string id)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "id", id },
            };

            return HttpRequest.DeleteAsync(URL, urlParam);
        }

        public Task<ResponseResult<GetLikeVideo>> GetLikeVideosAsync()
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
                { "myRating", "like" }
            };

            return HttpRequest.GetAsync<GetLikeVideo>(URL, urlParam);
        }

        public async Task<ResponseResult<VideoSingleUpload>> VideoSingleUploadAsync(FileStream fileStream, string title, string categoryId = "22", string privacyStatus = "private")
        {
            ResponseResult<VideoSingleUpload> responseResult = null;

            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "uploadType", "multipart" },
                { "part", "snippet,status" },
            };

            var jsonMetadata = new
            {
                snippet = new
                {
                    title,
                    categoryId,
                },
                status = new
                {
                    privacyStatus
                }
            };
            string jsonString = JsonConvert.SerializeObject(jsonMetadata);

            MultipartContent multipartContent = new MultipartContent("related");
            var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            multipartContent.Add(jsonContent);

            using (var videoContent = new StreamContent(fileStream))
            {
                videoContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
                multipartContent.Add(videoContent);

                responseResult = await HttpRequest.PostAsync<VideoSingleUpload>("videos", multipartContent, urlParam);
            }

            return responseResult;

            //return HttpRequest.PostAsync<VideoSingleUpload>(,);
        }

        public Task<ResponseResult> GetVideoResumableUploadURLAsync(string title, string categoryId = "22", string privacyStatus = "private")
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet,status" },
                { "uploadType", "resumable" }
            };

            var input = new
            {
                snippet = new
                {
                    title,
                    categoryId
                },
                status = new
                {
                    privacyStatus = "unlisted",
                    selfDeclaredMadeForKids = false
                }
            };

            return HttpRequest.PostAsync(URL, input, urlParam);
        }

        public async Task<ResponseResult<VideoResumableUpload>> VideoResumableUploadAsync(string uploadID, FileStream fileStream)
        {
            ResponseResult<VideoResumableUpload> responseResult = null;

            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet,status" },
                { "uploadType", "resumable" },
                { "upload_id", uploadID}
            };

            using (HttpContent httpContent = new StreamContent(fileStream))
            {
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");

                responseResult = await HttpRequest.PostAsync<VideoResumableUpload>("videos", httpContent, urlParam);
            }

            return responseResult;
        }
    }
}
