using System;
using System.Threading.Tasks;

namespace Zendesk.Ticket.Viewer.Service
{
    public interface ITicketService
    {
        Task<PagedList<Ticket>> GetAllTicketsAsync(int pageNumber, int pageSize);
    }
}
