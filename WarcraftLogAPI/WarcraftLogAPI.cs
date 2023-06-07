
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

using JsonWR;

namespace ReunionLogSoftware.WarcraftLogAPI{
    public class ClientData{
        [JsonProperty("client")]
        public ClientInfo Client {get; set;}
    }
    public class ClientInfo{
        [JsonProperty("client_id")]
        public string ClientID {get;set;}

        [JsonProperty("client_secret")]
        public string ClientSecret {get; set;}
    }
    public class WarcraftLogsApi{
        //Fields
        private HttpClient _client;
        private string _clientId;
        private string _clientSecret;
        private string clientPath;
        private ClientData clientData = null; 

        //Constructor
        public WarcraftLogsApi(){}

        public async Task InitializeAsync(){
            clientPath = Main.self.projectPath.GetProjectPath() + "/client.json";
            System.Console.WriteLine(clientPath);

            try
            {
                clientData = await JsonMain.ReadFromFileAsync<ClientData>(clientPath);
                _clientId = clientData.Client.ClientID;
                _clientSecret = clientData.Client.ClientSecret;

                if (_clientId != null && _clientSecret != null)
                {
                    Console.WriteLine(_clientId);
                    Console.WriteLine(_clientSecret);
                    _client = new HttpClient();
                }
                else
                {
                    System.Console.WriteLine("Error: Invalid client data in JSON file");
                    _clientId = "clientData?.Client?.ClientId";
                    _clientSecret = "clientData?.Client?.ClientSecret";
                    _client = new HttpClient();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Exception in the constructor of WarcraftLogsApi: {ex}");
                _clientId = "clientData?.Client?.ClientId";
                _clientSecret = "clientData?.Client?.ClientSecret";
                _client = new HttpClient();
            }
        }


        public async Task<ClientData> GetClient(string clientPath){
            try{
                clientData = await JsonMain.ReadFromFileAsync<ClientData>(clientPath);
                return clientData;
            }catch(Exception ex){
                System.Console.WriteLine($"Exception occurred in GetClient in WarcraftLogAPI: {ex}");
                return null;
            }
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
                File.WriteAllText(".Credential.json", tokenResponse.AccessToken);
                return tokenResponse.AccessToken;
            }
            System.Console.WriteLine("Problem in WarcraftLogAPI.cs <GetAccessData>");
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
            System.Console.WriteLine("Problem in WarcraftLogAPI.cs <GetReportData>");
            throw new Exception($"Failed to retrieve report data. Status code: {response.StatusCode}");            
        }

        private class TokenResponse{
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }
    }
}