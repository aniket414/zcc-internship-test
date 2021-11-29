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

            var pagedRoles = GetRolesAccordingToPaging(tickets, pageNumber, pageSize);
            pagedRoles.TotalRecords = totalRecords;

            return pagedRoles;
        }

        public async Task<Domain.Ticket> GetTicketAsync(string ticketId)
        {
            var ticket = await _dataAdapter.GetTicketAsync(ticketId);

            if (ticket == null)
                return null;

            return ticket;
        }

        private static PagedList<Domain.Ticket> GetRolesAccordingToPaging(List<Domain.Ticket> tickets, int pageNumber, int pageSize)
        {
            PagedList<Domain.Ticket> selectedRoles = new PagedList<Domain.Ticket>();

            var skipTickets = (pageNumber - 1) * pageSize;
            selectedRoles.AddRange(tickets.Skip(skipTickets).Take(pageSize).ToList());

            return selectedRoles;
        }
    }
}
