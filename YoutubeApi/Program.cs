using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Model;
using static YoutubeApi.Model.GetUnLikeVideo;

namespace YoutubeApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            string baseurl = "https://www.googleapis.com/youtube/v3/";
            string token = "";

            YoutubeContext youtubeContext = new YoutubeContext(baseurl, token);


            ////9. GetUnlikeVideo
            Task<GetUnLikeVideo> getUnLikeVideo = youtubeContext.Video.GetUnLikeVideosAsync();


            ////13. CreatePlayList
            string title = "20260816";

            Task<CreatePlayList> createPlayList = youtubeContext.PlayList.CreatePlayListAsync(title);


            ////14. DeletePlayList
            string id = "PLb2lmGNvOCns";

            Task<DeleteResult> deleteResult = youtubeContext.PlayList.DeletePlayListAsync(id);


            ////15. ModdifyPlayList
            string id = "PLb2lmGNvOCns";
            string title = "20260816";

            Task<ModifyPlayList> modifyPlayList = youtubeContext.PlayList.ModifyPlayListAsync(id, title);


            Console.ReadKey();
        }
    }
}
