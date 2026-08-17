using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApi.Interface
{
    internal interface IYoutubeContext
    {
        IVideo Video { get; }
        IPlayList PlayList { get; }
    }
}
