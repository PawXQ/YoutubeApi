using HttpUtility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Interface;
using YoutubeApi.Model;

namespace YoutubeApi.Service
{
    internal class Search : ISearch
    {
        IHttpRequest HttpRequest { get; set; }

        public string URL => "search";

        public Search(IHttpRequest httpRequest)
        {
            HttpRequest = httpRequest;
        }

        public Task<GetPublishVideo> GetPublishVideoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SearchVideo> SearchVideoAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
