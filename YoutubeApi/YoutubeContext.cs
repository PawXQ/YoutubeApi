using HttpUtility.Interface;
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

        public YoutubeContext(string baseurl, string token)
        {
            IHttpRequest httpRequest = new HttpRequest(baseUrl: baseurl, token: token);
            _video = new Video(httpRequest);
            _playList = new PlayList(httpRequest);
            _playListItem = new PlayListItem(httpRequest);
        }
    }
}
