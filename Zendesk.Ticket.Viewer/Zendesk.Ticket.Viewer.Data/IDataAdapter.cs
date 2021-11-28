using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zendesk.Ticket.Viewer.Data
{
    public interface IDataAdapter
    {
        Task<List<TicketResponse>> GetTicketsAsync();
    }
}
