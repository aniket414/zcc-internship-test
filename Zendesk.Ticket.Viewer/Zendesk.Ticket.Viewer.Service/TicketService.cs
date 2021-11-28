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
            var isExists = await _applicationService.ExistsAsync(applicationId);
            if (!isExists)
                throw Errors.ClientSide.EntityDoesNotExist("application", "ID", applicationId);

            var tenantId = TenantHelper.GetTenantForRoles(out var accountId);
            var store = await _storeFactory.BuildRoleStoreAsync(tenantId);

            var roles = await store.GetAllAsync(applicationId, pageSize: _defaultPageSize);
            if (roles == null || roles.Count == 0)
                return null;

            var totalRecords = roles.Count;

            var sortedRoles = SortRoles(roles);

            var pagedRoles = GetRolesAccordingToPaging(sortedRoles, pageNumber, pageSize);
            pagedRoles.TotalRecords = totalRecords;

            foreach (var pagedRole in pagedRoles)
            {
                if (!string.IsNullOrWhiteSpace(pagedRole.Description))
                    pagedRole.Description = pagedRole.Description.JavascriptEncode().HtmlEncode();
            }


            return pagedRoles;
        }
    }
}
