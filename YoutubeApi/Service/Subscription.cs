using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Interface;
using YoutubeApi.Model;

namespace YoutubeApi.Service
{
    internal class Subscription : ISubscription
    {
        public string URL => throw new NotImplementedException();

        public Task<Model.Subscription> SubscriptionChannelAsync(string channelId)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteResult> UnScriptionChannelAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
