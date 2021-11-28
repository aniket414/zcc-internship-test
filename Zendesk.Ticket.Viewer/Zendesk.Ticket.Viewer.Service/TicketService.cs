using System;
using System.Threading.Tasks;

namespace Zendesk.Ticket.Viewer.Service
{
    public class TicketService : ITicketService
    {
        public TicketService()
        {
        }

        public async Task<PagedList<Ticket>> GetAllTicketsAsync(string applicationId, int pageNumber, int pageSize)
        {
            
        }
    }
}
