using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Model;

namespace YoutubeApi.Interface
{
    internal interface ISearch : IBaseApi
    {
        //1. SearchVideo
        Task<SearchVideo> SearchVideoAsync(string query);
        //10. GetPublishVideo
        Task<GetPublishVideo> GetPublishVideoAsync();
    }
}
