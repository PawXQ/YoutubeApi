using HttpUtility.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            string token = "";

            YoutubeContext youtubeContext = new YoutubeContext(baseurl, token);


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
            string id = "j1TTQREaZMg";
            VideoRating videoRating = VideoRating.Like;
            ResponseResult videoRatingResponse = await youtubeContext.Video.VideoRating(id, videoRating);


            Console.WriteLine(videoRatingResponse.RawContent);
            Console.ReadKey();
        }
    }
}
