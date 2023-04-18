
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Newtonsoft.Json;

using Microsoft.AspNetCore;


namespace WarcraftLogAPI{
    public class WarcraftLogsApi{
        private readonly HttpClient _client;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public WarcraftLogsApi(string clientId, string clientSecret){
            _clientId = clientId;
            _clientSecret = clientSecret;
            _client = new HttpClient();
        }

        public async Task<string> GetAccessToken(){
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"},
                {"client_id", _clientId},
                {"client_secret", _clientSecret},
            });

            var response = await _client.PostAsync("https://www.warcraftlogs.com/oauth/token", content);

            if (response.IsSuccessStatusCode){
                var tokenResponse = await response.Content.ReadAsAsync<TokenResponse>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
                return tokenResponse.AccessToken;
            }

            throw new Exception($"Failed to retrieve access token. Status code: {response.StatusCode}");
        }

        public async Task<string> GetReportData(string reportCode){
            var query = @"query($code: String){reportData{report(code: $code){events(dataType: Deaths, endTime: 9999999999, wipeCutoff: 3){data}}}}";

            var variables = new{
                code = reportCode
            };

            var requestBody = new{
                query,
                variables
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://www.warcraftlogs.com/api/v2/client", content);

            if (response.IsSuccessStatusCode){
                var reportData = await response.Content.ReadAsStringAsync();
                File.WriteAllText("reportData.json", reportData);
                return reportData;
            }

            throw new Exception($"Failed to retrieve report data. Status code: {response.StatusCode}");
        }

        private class TokenResponse{
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }
    }
}