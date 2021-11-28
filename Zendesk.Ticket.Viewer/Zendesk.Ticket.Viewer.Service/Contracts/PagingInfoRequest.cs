using System;
namespace Zendesk.Ticket.Viewer.Service
{
    public class PagingInfoRequest
    {
        public PagingInfoRequest(string queryString)
        {
            (PageNumber, PageSize) = ResolveQueryString(queryString);
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        private (int, int) ResolveQueryString(string queryString)
        {
            if (string.IsNullOrWhiteSpace(queryString))
            {
                PageNumber = Keystore.PagingInfo.PageNumberDefaultValue;
                PageSize = Keystore.PagingInfo.PageSizeDefaultValue;

                return (PageNumber, PageSize);
            }
            else
            {
                var parameters = queryString.ToNameValueCollection();

                var parsedPageNumber = parameters.TryParseInt(Keystore.PagingInfo.PageNumber);
                var parsedPageSize = parameters.TryParseInt(Keystore.PagingInfo.PageSize);

                int pageNumber = parsedPageNumber == 0 ? Keystore.PagingInfo.PageNumberDefaultValue : parsedPageNumber;
                int pageSize = parsedPageSize == 0 ? Keystore.PagingInfo.PageSizeDefaultValue : parsedPageSize;

                //Validate Range
                if (pageNumber < Keystore.PagingInfo.PageNumberLowerLimit || pageNumber > Keystore.PagingInfo.PageNumberUpperLimit)
                    throw new Exception(Keystore.PagingInfo.PageNumber + " should be in range " + Keystore.PagingInfo.PageNumberLowerLimit + " - " + Keystore.PagingInfo.PageNumberUpperLimit);
                else if (pageSize < Keystore.PagingInfo.PageSizeLowerLimit || pageSize > Keystore.PagingInfo.PageSizeUpperLimit)
                    throw new Exception(Keystore.PagingInfo.PageSize + " should be in range " + Keystore.PagingInfo.PageSizeLowerLimit + " - " + Keystore.PagingInfo.PageSizeUpperLimit);

                return (pageNumber, pageSize);
            }
        }
    }
}
