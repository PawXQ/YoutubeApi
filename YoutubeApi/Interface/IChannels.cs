using HttpUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Model;

namespace YoutubeApi.Interface
{
    public interface IChannels : IBaseApi
    {
        Task<ResponseResult<GetChannelsInfo>> GetChannelsInfoAsync(string channelsId);
    }
}
