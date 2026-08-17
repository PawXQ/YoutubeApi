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
        Task<CreatePlayList> CreatePlayListAsync(string title);

        //14. DeletePlayList
        Task<DeleteResult> DeletePlayListAsync(string id);

        //15. ModdifyPlayList
        Task<ModifyPlayList> ModifyPlayListAsync(string id, string title);
    }
}
