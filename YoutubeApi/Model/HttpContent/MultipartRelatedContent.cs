using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApi.Model.HttpContent
{
    internal class MultipartRelatedContent : MultipartFormDataContent
    {
        public MultipartRelatedContent(string type) : base(type) { }
    }
}
