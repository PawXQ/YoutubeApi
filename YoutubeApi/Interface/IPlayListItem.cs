using HttpUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Model;

namespace YoutubeApi.Interface
{
    internal interface IPlayListItem : IBaseApi
    {
        //4. AddVideoItem
        Task<ResponseResult<AddVideoItem>> AddVideoItemAsync(string playlistId, string videoId);
    }
}
