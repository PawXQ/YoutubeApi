using HttpUtility.Interface;
using HttpUtility.Model;
using HttpUtility.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Interface;
using YoutubeApi.Service;

namespace YoutubeApi
{
    internal class YoutubeContext : IYoutubeContext
    {
        private IVideo _video;
        public IVideo Video => _video;

        private IPlayList _playList;
        public IPlayList PlayList => _playList;

        private IPlayListItem _playListItem;
        public IPlayListItem PlayListItem => _playListItem;

        private string _baseurl = "https://www.googleapis.com/youtube/v3/";

        public YoutubeContext()
        {
            CredentialService _credentialService = new CredentialService();

            IHttpRequest httpRequest = new HttpRequest(baseUrl: _baseurl, interceptor: new Interceptor(async x =>
            {
                string YoutubeApiAccessToken = await _credentialService.GetToken();
                x.Headers.Add("Authorization", $"Bearer {YoutubeApiAccessToken}");

                return InterceptorModel.ReplaceReuqest(x);
            }));

            _video = new Video(httpRequest);
            _playList = new PlayList(httpRequest);
            _playListItem = new PlayListItem(httpRequest);
        }
    }
}
