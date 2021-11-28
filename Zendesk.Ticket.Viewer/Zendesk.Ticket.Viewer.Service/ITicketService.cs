using System;
using System.Threading.Tasks;
using Zendesk.Ticket.Viewer.Domain;

namespace Zendesk.Ticket.Viewer.Service
{
    public interface ITicketService
    {
        Task<PagedList<Domain.Ticket>> GetAllTicketsAsync(int pageNumber, int pageSize);
    }
}
