using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zendesk.Ticket.Viewer.Domain
{
    public interface IDataAdapter
    {
        Task<List<Ticket>> GetTicketsAsync();
        Task<Ticket> GetTicketAsync(string ticketId);
    }
}
