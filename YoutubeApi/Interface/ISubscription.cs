using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Model;

namespace YoutubeApi.Interface
{
    internal interface ISubscription : IBaseApi
    {
        //11. SubscriptionChannel
        Task<Subscription> SubscriptionChannelAsync(string channelId);

        //12. UnSubscriptionChannel
        Task<DeleteResult> UnScriptionChannelAsync(string id);
    }
}
