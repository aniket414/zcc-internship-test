using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Zendesk.Ticket.Viewer.Domain
{
    public static class Client
    {
        private static HttpClient _client = new HttpClient();


        public static async Task<string> GetAsync(string url, string tenantId, string appName)
        {
            return await ExecuteAsync(HttpMethod.Get, url, tenantId, appName, null);
        }

        public static async Task<string> DeleteAsync(string url, string tenantId, string appName)
        {
            return await ExecuteAsync(HttpMethod.Delete, url, tenantId, appName, null);
        }

        public static async Task<string> PutAsync(string url, string tenantId, string appName, string jsonContent)
        {
            return await ExecuteAsync(HttpMethod.Put, url, tenantId, appName, jsonContent);
        }

        private static async Task<string> ExecuteAsync(HttpMethod method, string url, string tenantId, string appName, string jsonContent)
        {
            var request = new HttpRequestMessage(method, url);
            request.Headers.Add("oski-tenantId", tenantId);
            request.Headers.Add("oski-appName", appName);

            StringContent stringContent;
            if (jsonContent != null)
            {
                stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                request.Content = stringContent;
            }

            var response = await _client.SendAsync(request);
            var responseData = await response.Content.ReadAsByteArrayAsync();
            var responseString = Encoding.UTF8.GetString(responseData);
            return responseString;
        }
    }
}
