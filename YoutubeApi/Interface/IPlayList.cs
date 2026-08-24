using HttpUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Model;

namespace YoutubeApi.Interface
{
    internal interface IPlayList : IBaseApi
    {
        //13. CreatePlayList
        Task<ResponseResult<CreatePlayList>> CreatePlayListAsync(string title);

        //14. DeletePlayList
        Task<ResponseResult> DeletePlayListAsync(string id);

        //15. ModdifyPlayList
        Task<ResponseResult<ModifyPlayList>> ModifyPlayListAsync(string id, string title);
    }
}
