using System;

namespace Zendesk.Ticket.Viewer.Data
{
    internal static class TicketTranslator
    {
        internal static Domain.Ticket ToDomainModel(this Tickets tickets)
        {
            if (tickets == null)
                return null;

            var ticketDomainModel = new Domain.Ticket()
            {
                Id = role.Id,
                Description = role.Description,
                CreatedAtUtc = role.CreatedAt,
                UpdatedAtUtc = role.LastUpdatedAt,
            };

            if (role.PermissionIds != null)
                ticketDomainModel.PermissionIds.AddRange(role.PermissionIds);

            return ticketDomainModel;
        }
    }
}
