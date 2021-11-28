using System;
using System.Threading.Tasks;
using Zendesk.Ticket.Viewer.Domain;

namespace Zendesk.Ticket.Viewer.Service
{
    public class TicketService : ITicketService
    {
        private readonly IDataAdapter _dataAdapter;
        public TicketService(IDataAdapter dataAdapter)
        {
            _dataAdapter = dataAdapter;
        }

        public async Task<PagedList<Domain.Ticket>> GetAllTicketsAsync(int pageNumber, int pageSize)
        {
            var response = await _dataAdapter.GetTicketsAsync();
            return null;
        }
    }
}
