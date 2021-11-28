using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zendesk.Ticket.Viewer.Data
{
    public class ZendeskAdapter : IDataAdapter
    {
        private readonly static string _email = "email";
        private readonly string _authUsername = $"{_email}/token";
        private readonly string _authToken = "token";
        private readonly string _baseUrl = "https://zccinternshiptest.zendesk.com/";

        public async Task<List<TicketResponse>> GetTicketsAsync()
        {
            try
            {
                var getTicketsURL = $"{_baseUrl}api/v2/tickets";

                var result = Task.Run(async () => await Client.GetAsync(getTicketsURL, _authUsername, _authToken)).Result;

                if (string.IsNullOrEmpty(result))
                    return null;

                else
                {
                    var ticketResponse = JsonConvert.DeserializeObject<TicketResponse>(result);
                    if (ticketResponse != null && ticketResponse.tickets.Count > 1)
                    {
                        return null;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
