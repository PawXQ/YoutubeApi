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


            string baseurl = "https://www.googleapis.com/youtube/v3/";
            string uploadurl = "https://www.googleapis.com/upload/youtube/v3/";
            string token = "ya29.a0AdMD6EglvkgfcUAusgDgr6VwT1COmPkDK4YHnJXs_XU0vf3PvYMcEBhsPrJjnHAEoXM3OdciqZjURZozYSuCCIMX7wkS6qzUnvTwgv3tndwi0TSVs-hsU8lx953qNrsOMH-t77kZl1gOuNfkUtRFfwfNvbkprBjLZewc-NK4m8tVeBFEHOhLmPrn-sfzdPSdCnaBeBkaCgYKAX0SARcSFQHGX2Mi6UhaSXDZCszrc5JUghxSSA0206";

            YoutubeContext youtubeContext = new YoutubeContext(uploadurl, token);


            //////9. GetUnlikeVideo
            //Task<GetUnLikeVideo> getUnLikeVideo = youtubeContext.Video.GetUnLikeVideosAsync();


            ////13. CreatePlayList
            //string title = "20260821";

            //ResponseResult<CreatePlayList> createPlayList = await youtubeContext.PlayList.CreatePlayListAsync(title);


            //////14. DeletePlayList
            //string id = "PLMiT3c4Gvk6M";

            //Task<DeleteResult> deleteResult = youtubeContext.PlayList.DeletePlayListAsync(id);


            //////15. ModdifyPlayList
            //string id = "PLb2lmGNvOCns";
            //string title = "20260816";

            //Task<ModifyPlayList> modifyPlayList = youtubeContext.PlayList.ModifyPlayListAsync(id, title);

            //////4. AddVideoItemAsync
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

            string title = "20260830-3";
            string videoPath = @"C:/Users/Albert/Downloads/file_example_MP4_1920_18MG.mp4";
            ResponseResult<VideoSingleUpload> responseResult = null;
            using (var fileStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                //var fileStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                responseResult = await youtubeContext.Video.VideoSingleUploadAsync(fileStream: fileStream, title: title);
            }

            Console.WriteLine(responseResult.Message);
            Console.WriteLine(responseResult.RawContent);
            Console.ReadKey();
        }
    }
}
