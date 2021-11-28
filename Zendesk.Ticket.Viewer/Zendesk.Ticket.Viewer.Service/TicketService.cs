using System;
using System.Threading.Tasks;
using Zendesk.Ticket.Viewer.Data;

namespace Zendesk.Ticket.Viewer.Service
{
    public class TicketService : ITicketService
    {
        private readonly IDataAdapter _dataAdapter;
        public TicketService(IDataAdapter dataAdapter)
        {
            _dataAdapter = dataAdapter;
        }

        public async Task<PagedList<Ticket>> GetAllTicketsAsync(int pageNumber, int pageSize)
        {
            var response = await _dataAdapter.GetTicketsAsync();
            return null;
        }
    }
}
