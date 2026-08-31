using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApi
{
    public class SingleUploadDemo
    {
        // HttpClient 在 .NET Framework 中應保持單例 (Singleton) 以避免 Socket 耗盡 (Socket Exhaustion)
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// 透過純 HTTP POST (multipart/related) 上傳影片至 YouTube (.NET 4.7.2)
        /// </summary>
        /// <param name="videoPath">影片本機路徑</param>
        /// <param name="accessToken">OAuth 2.0 Bearer Token</param>
        public static async Task UploadVideoAsync(string videoPath, string accessToken)
        {
            string requestUrl = "https://www.googleapis.com/upload/youtube/v3/videos?uploadType=multipart&part=snippet,status";

            // 為了不依賴第三方套件，直接使用 Raw JSON 字串
            string jsonMetadata = @"{
                ""snippet"": {
                    ""title"": ""C# 4.7.2 純 HTTP 上傳測試"",
                    ""description"": ""這是一支透過 HttpClient 實作 multipart/related 格式上傳的測試影片。"",
                    ""categoryId"": ""22""
                },
                ""status"": {
                    ""privacyStatus"": ""private""
                }
            }";

            // 使用傳統的 using 區塊 (C# 7.3 規範)
            using (var multipartContent = new MultipartContent("related"))
            {
                // --- Part 1: JSON Metadata ---
                var jsonContent = new StringContent(jsonMetadata, Encoding.UTF8, "application/json");
                multipartContent.Add(jsonContent);

                // --- Part 2: Video File ---
                // 使用 FileStream 控制記憶體用量，避免大檔案造成 LOH (Large Object Heap) 破碎
                using (var fileStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (var videoContent = new StreamContent(fileStream))
                    {
                        videoContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
                        multipartContent.Add(videoContent);

                        using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl))
                        {
                            requestMessage.Content = multipartContent;
                            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                            Console.WriteLine("開始上傳影片...");

                            // 發送請求。HttpClient 會從 FileStream 邊讀邊傳，不會吃光 RAM
                            using (HttpResponseMessage response = await _httpClient.SendAsync(requestMessage))
                            {
                                string responseBody = await response.Content.ReadAsStringAsync();

                                if (response.IsSuccessStatusCode)
                                {
                                    Console.WriteLine("上傳成功！");
                                    Console.WriteLine(responseBody);
                                }
                                else
                                {
                                    Console.WriteLine($"上傳失敗: {(int)response.StatusCode} {response.ReasonPhrase}");
                                    Console.WriteLine(responseBody);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
