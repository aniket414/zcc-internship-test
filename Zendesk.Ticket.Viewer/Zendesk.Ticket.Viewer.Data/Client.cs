using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Zendesk.Ticket.Viewer
{
    public static class Client
    {
        private static HttpClient _client = new HttpClient();


        public static async Task<string> GetAsync(string url, string username, string password)
        {
            return await ExecuteAsync(HttpMethod.Get, url, username, password, null);
        }

        public static async Task<string> DeleteAsync(string url, string username, string password)
        {
            return await ExecuteAsync(HttpMethod.Delete, url, username, password, null);
        }

        public static async Task<string> PutAsync(string url, string username, string password, string jsonContent)
        {
            return await ExecuteAsync(HttpMethod.Put, url, username, password, jsonContent);
        }

        private static async Task<string> ExecuteAsync(HttpMethod method, string url, string username, string password, string jsonContent)
        {
            var request = new HttpRequestMessage(method, url);
            request.Headers.Add("Content-Type", "application/json");

            StringContent stringContent;
            if (jsonContent != null)
            {
                stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                request.Content = stringContent;
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", GetAuthorizationHeaderValue(username, password));

            var response = await _client.SendAsync(request);
            var responseData = await response.Content.ReadAsByteArrayAsync();
            var responseString = Encoding.UTF8.GetString(responseData);
            return responseString;
        }

        private static string GetAuthorizationHeaderValue(string username, string password)
        {
            string credentialsToEncode = $"{username}:{password}";
            var bytesUsernamePassword = Encoding.GetEncoding("iso-8859-1").GetBytes(credentialsToEncode);
            string encodedText = Convert.ToBase64String(bytesUsernamePassword);
            return encodedText;
        }
    }
}
