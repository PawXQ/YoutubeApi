using HttpUtility.Interface;
using HttpUtility.Model;
using HttpUtility.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Interface;
using YoutubeApi.Service;

namespace YoutubeApi
{
    public class YoutubeContext : IYoutubeContext
    {
        private IComment _comment;
        public IComment Comment => _comment;

        private ICommentThread _commentThread;
        public ICommentThread CommentThread => _commentThread;

        private IPlayList _playList;
        public IPlayList PlayList => _playList;

        private IPlayListItem _playListItem;
        public IPlayListItem PlayListItem => _playListItem;

        private ISearch _search;
        public ISearch Search => _search;

        private ISubscription _subscription;
        public ISubscription Subscription => _subscription;

        private IVideo _video;
        public IVideo Video => _video;


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

            _comment = new Comment(httpRequest);
            _commentThread = new CommentThread(httpRequest);
            _playList = new PlayList(httpRequest);
            _playListItem = new PlayListItem(httpRequest);
            _search = new Search(httpRequest);
            _subscription = new Subscription(httpRequest);
            _video = new Video(httpRequest);
        }
    }
}
