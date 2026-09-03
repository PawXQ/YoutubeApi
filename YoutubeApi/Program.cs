using HttpUtility.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Enum;
using YoutubeApi.Model;
using static YoutubeApi.Model.GetUnLikeVideo;


namespace YoutubeApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            //string baseurl = "https://www.googleapis.com/youtube/v3/";
            string uploadurl = "https://www.googleapis.com/upload/youtube/v3/";
            string token = "ya29.a0AdMD6EiB_HVqQb5TZWe5eh7l4WuKXXcUeenEsbF8VyZwx5fBiPNsFr__O0r8tBvYRHCKQ84OgfT_2-J2FEaqgMiG-5OUcKzOnSTVPLf6PsexGalEzQ4Mt1gOk2wugVjZiIHnP9nlPTrbzhXAgXrNQZoBhKsT_eMfmbCwxiFrRYrzCmyjyMXq00wirbDwV4_2qbX2BC4u_U7b5ak66hHs9PPnsi7DMYomNFV2Q8w-ZrQ2qpYdWXRUUNJtT14Pu1xiAHRIEXaPodQrcCpujQ452jJerTgaCgYKAdcSARcSFQHGX2MiDP9VfhrVb6pgUxemntbqsw0290";

            //YoutubeContext youtubeContext = new YoutubeContext(baseurl, token);
            YoutubeContext youtubeContext = new YoutubeContext(uploadurl, token);


            ////9. GetUnlikeVideo
            //ResponseResult<GetUnLikeVideo> responseResult = await youtubeContext.Video.GetUnLikeVideosAsync();


            ////13. CreatePlayList
            //string title = "20260821";

            //ResponseResult<CreatePlayList> createPlayList = await youtubeContext.PlayList.CreatePlayListAsync(title);


            ////14. DeletePlayList
            //string id = "PLMiT3c4Gvk6M";

            //Task<DeleteResult> deleteResult = youtubeContext.PlayList.DeletePlayListAsync(id);


            //////15. ModdifyPlayList
            //string id = "PLb2lmGNvOCns";
            //string title = "20260816";

            //Task<ModifyPlayList> modifyPlayList = youtubeContext.PlayList.ModifyPlayListAsync(id, title);

            ////4. AddVideoItemAsync
            //string playListId = "PLDNxnLJzXwho";
            //string videoId = "4mJayYlfcWo";
            //ResponseResult<AddVideoItem> addVideoItem = await youtubeContext.PlayListItem.AddVideoItemAsync(playListId, videoId);

            //////3. VideoRating
            //string id = "j1TTQREaZMg";
            //VideoRating videoRating = VideoRating.Like;
            //ResponseResult videoRatingResponse = await youtubeContext.Video.VideoRating(id, videoRating);



            ////5.2 VideoSingleUpload

            //test
            //await SingleUploadDemo.UploadVideoAsync(@"C:/Users/Albert/Downloads/file_example_MP4_480_1_5MG.mp4", token);

            //string title = "20260830-3";
            string videoPath = @"C:/Users/Albert/Downloads/file_example_MP4_480_1_5MG.mp4";
            //ResponseResult<VideoSingleUpload> responseResult = null;
            //using (var fileStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            //{
            //    //var fileStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            //    responseResult = await youtubeContext.Video.VideoSingleUploadAsync(fileStream: fileStream, title: title);
            //}

            //5.1.1 VideoResumableUploadURL
            //string title = "20260903-1";
            //ResponseResult responseResult = await youtubeContext.Video.GetVideoResumableUploadURLAsync(title: title);

            //string locationUrl = responseResult.Headers["Location"];
            //Uri uri = new Uri(locationUrl);
            //var queryParameters = System.Web.HttpUtility.ParseQueryString(uri.Query);
            //string uploadId = queryParameters["upload_id"];
            //Console.WriteLine(uploadId);

            //5.1.2 VideoResumableUpload
            string uploadID = "AJjja9aKoFLrF7N8x5-cjg2C2ouitX3LxMtCO58_nn13nFaviZLeAD4m9k5Ou-P8bmxbOpbUmeSkXmRLlZ2-2Lw4nAn9QLgi3jcj0UwiQMalLaA";

            ResponseResult<VideoResumableUpload> responseResult = null;

            using (var fileStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                responseResult = await youtubeContext.Video.VideoResumableUploadAsync(uploadID, fileStream: fileStream);
            }


            Console.WriteLine(responseResult.StatusCode);
            Console.WriteLine(responseResult.Message);
            foreach (var kvp in responseResult.Headers)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            Console.WriteLine(responseResult.RawContent);
            Console.ReadKey();
        }
    }
}
