using System;
namespace Zendesk.Ticket.Viewer.Service
{
    public static class PagingInfoTranslator
    {
        public static PagingInfo ToDataContract(this PagingInfoRequest pagingInfoRequest, int totalRecords)
        {
            if (pagingInfoRequest == null)
                return null;

            return new PagingInfo()
            {
                PageNumber = pagingInfoRequest.PageNumber,
                PageSize = pagingInfoRequest.PageSize,
                TotalRecords = totalRecords
            };
        }
    }
}
