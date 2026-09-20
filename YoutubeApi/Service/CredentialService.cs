using CredentialManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Model;

namespace YoutubeApi.Service
{
    internal class CredentialService
    {
        string accessToken { get; set; }
        string accessTokenKV { get; set; }
        string accessTokenExpireTime { get; set; }
        string accessTokenExpireTimeKV { get; set; }
        string refreshToken { get; set; }
        string refreshTokenKV { get; set; }
        string refreshTokenExpireTime { get; set; }
        string refreshTokenExpireTimeKV { get; set; }
        string clientSecret => "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";
        string clientSecretKV => "ClientSecret=" + this.clientSecret;
        public List<string> credentialPasswds { get; set; } = new List<string>();
        Dictionary<string, string> credentialPasswdsDict { get; set; } = new Dictionary<string, string>();
        long currentSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        string targetId => "AAAA";
        Credential storedCred { get; set; }

        public CredentialService()
        {
            this.storedCred = new Credential() { Target = this.targetId, PersistanceType = PersistanceType.LocalComputer };
        }

        public async Task<string> GetToken()
        {
            this.LoadToken();
            this.SaveToken();
            await this.RenewToken();
            this.LoadToken();
            this.accessToken = this.credentialPasswdsDict.ContainsKey("AccessToken") ? this.credentialPasswdsDict["AccessToken"] : null;

            return this.accessToken;
        }

        private void LoadToken()
        {
            if (!storedCred.Load())
            {
                this.credentialPasswdsDict["ClientSecret"] = "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";
            }
            else
            {
                this.credentialPasswdsDict = storedCred.Password
                .Split(new[] { ',' })
                .Select(x => x.Split('='))
                .ToDictionary(y => y[0], y => y[1]);
            }
        }

        private void SaveToken()
        {
            this.accessToken = credentialPasswdsDict.ContainsKey("AccessToken") ? credentialPasswdsDict["AccessToken"] : null;
            this.accessTokenExpireTime = credentialPasswdsDict.ContainsKey("AccessTokenExpireTime") ? credentialPasswdsDict["AccessTokenExpireTime"] : null;
            this.refreshToken = credentialPasswdsDict.ContainsKey("RefreshToken") ? credentialPasswdsDict["RefreshToken"] : null;
            this.refreshTokenExpireTime = credentialPasswdsDict.ContainsKey("RefreshTokenExpireTime") ? credentialPasswdsDict["RefreshTokenExpireTime"] : null;
        }

        private async Task RenewToken()
        {

            if (this.accessTokenExpireTime == null || long.Parse(this.accessTokenExpireTime) < currentSeconds)
            {
                Auth auth = new Auth();
                GoogleTokenResponse googleTokenResponse = null;
                if (this.refreshTokenExpireTime == null || long.Parse(this.refreshTokenExpireTime) < currentSeconds)
                {
                    googleTokenResponse = await auth.Login();

                    Console.WriteLine(googleTokenResponse.access_token);
                }
                else
                {
                    googleTokenResponse = await auth.Rotate(refreshToken);
                    // rotate
                }

                this.accessTokenKV = "AccessToken=" + googleTokenResponse.access_token;
                this.accessTokenExpireTimeKV = "AccessTokenExpireTime=" + (googleTokenResponse.expires_in + currentSeconds).ToString();
                this.refreshTokenKV = "RefreshToken=" + googleTokenResponse.refresh_token;
                this.refreshTokenExpireTimeKV = "RefreshTokenExpireTime=" + (currentSeconds + 604800).ToString();
                //this.clientSecretKV = "ClientSecret=" + "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";
                credentialPasswds.Add(this.accessTokenKV);
                credentialPasswds.Add(this.accessTokenExpireTimeKV);
                credentialPasswds.Add(this.refreshTokenKV);
                credentialPasswds.Add(this.refreshTokenExpireTimeKV);
                credentialPasswds.Add(this.clientSecretKV);

                var cred = new Credential(
                "YoutubeApi",
                // 亦可用加密過的密碼取代明碼密碼，再多一道鎖
                string.Join(",", credentialPasswds),
                targetId,
                CredentialType.Generic);
                cred.Save();
            }
        }
    }
}
