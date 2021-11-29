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
        /// <summary>
        /// Email, Token and URL is hard coded here
        /// However
        /// We should store them in encrypted form in Configuration Store such as Consul [consul.io]
        /// Or
        /// We can also store them in AWS Parameter Store and fetch from there.
        /// </summary>
        private readonly static string _email = "aniket414@gmail.com";
        private readonly string _authUsername = $"{_email}/token";
        private readonly string _authToken = "aWF52RKH1zsONVtbK37ckIVDVoFV3bpugyhVyLHM";
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
                    var ticketResponse = JsonConvert.DeserializeObject<TicketsResponse>(result);
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
                throw new Exception("Could not connect to Zendesk server", ex);
            }
        }

        public async Task<Domain.Ticket> GetTicketAsync(string ticketId)
        {
            try
            {
                var getTicketsURL = $"{_baseUrl}api/v2/tickets/{ticketId}";

                var result = Task.Run(async () => await Client.GetAsync(getTicketsURL, _authUsername, _authToken)).Result;

                if (string.IsNullOrEmpty(result))
                    return null;

                else
                {
                    var ticketResponse = JsonConvert.DeserializeObject<TicketResponse>(result);
                    if (ticketResponse != null)
                    {
                        return ticketResponse.ticket.ToDomainModel();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not connect to Zendesk server", ex);
            }
        }
    }
}
