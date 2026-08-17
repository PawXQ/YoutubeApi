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
            string token = "ya29.a0AdMD6Ei8Tb07rgU0OyC97qubZmdThSc5AjzuHEwykEZwXF6fX8JbWBH4CqKD6jnVwW0oqr_evXNkjDa1k4fSCqJeSS26Y6Rc4WXioaDMTlTHy1r9oHp_LOvyY8LrRCLussDRjx6s3ZFVeqFOVawN3YUqttD8y40kqZoNT3eNb356Zsb95nc7m5zct6eBgtoM1B8pHezzfs4Qq0lLXyTmAQG3vys8km9VD6hDFZps2yAp-lmtqN2YugQp6Ya-vOqdIotcv0eyjT6pwWDrX6JN-3HhYJZfaCgYKAdUSARcSFQHGX2MiQPE3YvSY6t6MBy0rgCcXBA0291";

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
