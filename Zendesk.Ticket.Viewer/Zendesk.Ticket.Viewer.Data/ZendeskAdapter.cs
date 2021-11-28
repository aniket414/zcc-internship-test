using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zendesk.Ticket.Viewer.Domain;

namespace Zendesk.Ticket.Viewer.Data
{
    public class ZendeskAdapter : IDataAdapter
    {
        private readonly static string _email = "email";
        private readonly string _authUsername = $"{_email}/token";
        private readonly string _authToken = "token";
        private readonly string _baseUrl = "https://zccinternshiptest.zendesk.com/";

        public async Task<List<Domain.Ticket>> GetTicketsAsync()
        {
            var listOfTickets = new List<Domain.Ticket>();
            try
            {
                var getTicketsURL = $"{_baseUrl}api/v2/tickets";

                var result = Task.Run(async () => await Client.GetAsync(getTicketsURL, _authUsername, _authToken)).Result;

                if (string.IsNullOrEmpty(result))
                    return null;

                else
                {
                    var ticketResponse = JsonConvert.DeserializeObject<TicketResponse>(result);
                    if (ticketResponse != null && ticketResponse.tickets.Count > 0)
                    {
                        foreach (var tickets in ticketResponse.tickets)
                        {
                            listOfTickets.Add(tickets.ToDomainModel());
                        }
                    }
                }

                return listOfTickets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
