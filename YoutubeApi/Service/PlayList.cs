using HttpUtility.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Interface;
using YoutubeApi.Model;

namespace YoutubeApi.Service
{
    internal class PlayList : IPlayList
    {
        IHttpRequest HttpRequest { get; set; }

        public string URL => "playlists";

        public PlayList(IHttpRequest httpRequest)
        {
            HttpRequest = httpRequest;
        }

        public Task<CreatePlayList> CreatePlayListAsync(string title)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
            };

            var input = new
            {
                snippet = new
                {
                    title
                }
            };

            return HttpRequest.PostAsync<CreatePlayList>(URL, input, urlParam);
        }

        public async Task<DeleteResult> DeletePlayListAsync(string id)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "id", id },
            };

            HttpResponseMessage response = await HttpRequest.DeleteAsync(URL, urlParam);

            return new DeleteResult
            {
                IsSuccess = response.IsSuccessStatusCode,
                StatusCode = (int)response.StatusCode,
                Message = response.ReasonPhrase.ToString(),
            };
        }

        public Task<ModifyPlayList> ModifyPlayListAsync(string id, string title)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>
            {
                { "part", "snippet" },
            };

            var input = new
            {
                id,
                snippet = new
                {
                    title
                }
            };

            return HttpRequest.PutAsync<ModifyPlayList>(URL, input, urlParam);
        }
    }
}
