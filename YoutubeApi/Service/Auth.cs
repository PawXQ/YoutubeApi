using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Interface;
using YoutubeApi.Model;

namespace YoutubeApi.Service
{
    internal class Auth : IAuth
    {
        string ClientId => "867177985894-3504rhd0nd0n2j9eubmqbbut7mc19l1r.apps.googleusercontent.com";
        string RedirectUri => "http://localhost:8080";
        string ResponseType => "code";
        string Scope => "https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube.force-ssl%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube.readonly%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutube.upload%20https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fyoutubepartner";
        string CodeChallengeMethod => "S256";
        string AccountsBaseURL => "https://accounts.google.com/o/oauth2/v2/";
        string ClientSecret => "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";
        string GrantType => "authorization_code";
        string Oauth2BaseURL => "https://oauth2.googleapis.com/";

        public async Task<GoogleTokenResponse> Login()
        {
            int codeVerifterLength = getCodeVerifierLength();

            string codeVerifier = RandomString(codeVerifterLength);

            string base64URL = GenerateCodeChallenge(codeVerifier);

            string apiCode = await GetApiCode(base64URL);

            GoogleTokenResponse googleTokenResponse = await GetApiAccessToken(codeVerifier, apiCode);

            return googleTokenResponse;
        }

        public async Task<GoogleTokenResponse> Rotate(string refreshToken)
        {
            GoogleTokenResponse googleTokenResponse = await GetApiAccessToken(refreshToken);

            return googleTokenResponse;
        }

        private int getCodeVerifierLength()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int length = random.Next(43, 128);
            return length;
        }

        private string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private string GenerateCodeChallenge(string codeVerifier)
        {
            using (var sha256 = SHA256.Create())
            {
                // 1. 直接對原始字串取 ASCII Bytes，並計算 SHA256 雜湊 (不要轉成16進位字串)
                byte[] challengeBytes = sha256.ComputeHash(Encoding.ASCII.GetBytes(codeVerifier));

                // 2. 將 Byte 陣列轉換為 Base64URL 格式，並移除結尾的 '='
                return Convert.ToBase64String(challengeBytes)
                    .Replace("+", "-")
                    .Replace("/", "_")
                    .TrimEnd('=');
            }
        }

        private string buildQueryString(string url, Dictionary<string, string> urlParam)
        {
            if (urlParam == null) return url;

            string parameter = "?";
            url += parameter;

            foreach (var kvp in urlParam)
            {
                url += $"{kvp.Key}={kvp.Value}&";
            }

            url = url.TrimEnd('&');

            return url;
        }

        private async Task<string> GetApiCode(string base64URL)
        {
            Dictionary<string, string> urlParam = new Dictionary<string, string>()
            {
                { "client_id", this.ClientId },
                { "redirect_uri", this.RedirectUri },
                { "response_type", this.ResponseType },
                { "scope", this.Scope },
                { "code_challenge",base64URL },
                { "code_challenge_method", this.CodeChallengeMethod }
            };

            string url = buildQueryString("auth", urlParam);

            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://localhost:8080/");
            server.Start();

            ProcessStartInfo processStartInfo = new ProcessStartInfo(this.AccountsBaseURL + url);
            Process.Start(processStartInfo);

            HttpListenerContext context = await server.GetContextAsync();
            HttpListenerRequest httpListenerRequest = context.Request;

            string responseString = "<html><head><meta charset='utf-8'></head><body style='font-family: sans-serif; text-align: center; margin-top: 50px;'><h1>授權成功！</h1><p>您現在可以關閉此視窗並返回應用程式。</p></body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            // 2. 取得 Response 物件並設定回傳內容的長度
            HttpListenerResponse response = context.Response;
            response.ContentLength64 = buffer.Length;

            // 3. 將內容寫入輸出串流
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            // 4. 關閉輸出串流，這步會讓瀏覽器收到完整回應並停止轉圈圈
            output.Close();

            // 5. 如果這個 Listener 只是為了接這一次 OAuth 回傳，處理完後記得關閉
            server.Stop();

            string youTubeApiCode = httpListenerRequest.QueryString["code"];

            return youTubeApiCode;
        }

        private async Task<GoogleTokenResponse> GetApiAccessToken(string codeVerifier, string apiCode)
        {
            Dictionary<string, string> tokenRequestParams = new Dictionary<string, string>()
            {
                { "client_id", this.ClientId },
                { "client_secret",this.ClientSecret },
                { "code", apiCode },
                { "code_verifier", codeVerifier },
                { "grant_type", this.GrantType },
                { "redirect_uri", this.RedirectUri },
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.Oauth2BaseURL);

            FormUrlEncodedContent content = new FormUrlEncodedContent(tokenRequestParams);

            HttpResponseMessage httpResponseMessage = await client.PostAsync("token", content);
            string rawContent = await httpResponseMessage.Content.ReadAsStringAsync();

            GoogleTokenResponse googleTokenResponse = JsonConvert.DeserializeObject<GoogleTokenResponse>(rawContent);

            return googleTokenResponse;
        }

        private async Task<GoogleTokenResponse> GetApiAccessToken(string refreshToken)
        {
            Dictionary<string, string> tokenRequestParams = new Dictionary<string, string>()
            {
                { "client_id", this.ClientId },
                { "client_secret",this.ClientSecret },
                { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken },
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.Oauth2BaseURL);

            FormUrlEncodedContent content = new FormUrlEncodedContent(tokenRequestParams);

            HttpResponseMessage httpResponseMessage = await client.PostAsync("token", content);
            string rawContent = await httpResponseMessage.Content.ReadAsStringAsync();

            GoogleTokenResponse googleTokenResponse = JsonConvert.DeserializeObject<GoogleTokenResponse>(rawContent);

            return googleTokenResponse;
        }
    }
}
