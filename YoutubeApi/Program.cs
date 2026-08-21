using Newtonsoft.Json;
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
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            string baseurl = "https://www.googleapis.com/youtube/v3/";
            string token = "ya29.a0AdMD6EicD-z-NzaWZrG8AZ46T0zIR6rE3TvYJbRzZnhfDrNk76cJ6tvE_PZPMeX3Wyiqiq4cLtxqFZJLy7vzqbwS-dlKJKMVK-Ez5u7AlRYy45RcYRObdMqi9iQCoFtdRQ3cyj_q7woYC3PPCw96FQQZ2uBVqzen-IfTDOsRuUvZ_qvH49GaIH66rwDt4K2gzbxSFlnr0qGtslkj9h9zrnK4uryag5ECx7Vwc-zsHLXhNBEkm-Kzj_L0ghkHxVVLKh6CHomRQjbslP3CIyuAJ6F_UbgaCgYKARgSARcSFQHGX2MiieDidUbFf1orpXteNzNm3Q0290";

            YoutubeContext youtubeContext = new YoutubeContext(baseurl, token);


            //////9. GetUnlikeVideo
            //Task<GetUnLikeVideo> getUnLikeVideo = youtubeContext.Video.GetUnLikeVideosAsync();


            ////13. CreatePlayList
            //string title = "20260821";

            //CreatePlayList createPlayList = await youtubeContext.PlayList.CreatePlayListAsync(title);


            //////14. DeletePlayList
            //string id = "PLMiT3c4Gvk6M";

            //Task<DeleteResult> deleteResult = youtubeContext.PlayList.DeletePlayListAsync(id);


            //////15. ModdifyPlayList
            //string id = "PLb2lmGNvOCns";
            //string title = "20260816";

            //Task<ModifyPlayList> modifyPlayList = youtubeContext.PlayList.ModifyPlayListAsync(id, title);

            ////4. AddVideoItemAsync
            string playListId = "PLMiT3c4Gvk6M";
            string videoId = "4mJayYlfcWo";
            AddVideoItem addVideoItem = await youtubeContext.PlayListItem.AddVideoItemAsync(playListId, videoId);


            Console.WriteLine(JsonConvert.SerializeObject(addVideoItem));
            Console.ReadKey();
        }
    }
}
