using HttpUtility.Model;
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
            string token = "ya29.a0AdMD6Ej1Nash1A-rsatvq9N9amjUlvIB1RPa3o_pRVylzailI27i_f7ednGcg48OhY03noBriWDiY_UjxX4wsYVywdH2twDWgAV7omGiLBSFs5YQcoGikPfyGmC-SFel_BRiI52N0Ugoxjl3nMRYqpEQ9HdTo-FAYTsPp_akubQs1ThyPevUs38PaWJynIc2QjIozfr2jEwlWA6M1ST2db03zTDKo4G9hcm1CCdXjsNlSVZzeO2JgBuRyc5Y1smX_5zQ5i2k-6FEW55ygqosGrZnEcgaCgYKATQSARcSFQHGX2Mi0QWHbGj5J8fuJnq1En5Rrw0290";

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

            ////4. AddVideoItemAsync
            string playListId = "PLDNxnLJzXwho";
            string videoId = "4mJayYlfcWo";
            ResponseResult<AddVideoItem> addVideoItem = await youtubeContext.PlayListItem.AddVideoItemAsync(playListId, videoId);


            Console.WriteLine(addVideoItem.RawContent);
            Console.ReadKey();
        }
    }
}
