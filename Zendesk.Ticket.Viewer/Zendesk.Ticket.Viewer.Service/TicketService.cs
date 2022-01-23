using System;
using System.Collections.Generic;
using System.Linq;
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
            var tickets = await _dataAdapter.GetTicketsAsync();

            if (tickets == null || tickets.Count == 0)
                return null;

            var totalRecords = tickets.Count;

            var pagedTickets = GetTicketsAccordingToPaging(tickets, pageNumber, pageSize);
            pagedTickets.TotalRecords = totalRecords;

            return pagedTickets;
        }

        public async Task<Domain.Ticket> GetTicketAsync(string ticketId)
        {
            if(string.IsNullOrEmpty(ticketId))
            {
                throw new ArgumentNullException("Id");
            }

            var ticket = await _dataAdapter.GetTicketAsync(ticketId);

            if (ticket == null)
                return null;

            return ticket;
        }

        private static PagedList<Domain.Ticket> GetTicketsAccordingToPaging(List<Domain.Ticket> tickets, int pageNumber, int pageSize)
        {
            PagedList<Domain.Ticket> selectedTickets = new PagedList<Domain.Ticket>();

            var skipTickets = (pageNumber - 1) * pageSize;
            selectedTickets.AddRange(tickets.Skip(skipTickets).Take(pageSize).ToList());

            return selectedTickets;
        }
    }
}
