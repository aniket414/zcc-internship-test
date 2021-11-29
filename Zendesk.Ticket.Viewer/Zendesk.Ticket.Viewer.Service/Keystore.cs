using System;
namespace Zendesk.Ticket.Viewer.Service
{
    public class Keystore
    {
        public static class PagingInfo
        {
            public static readonly string PageNumber = "pageNumber";
            public static readonly string PageSize = "pageSize";

            public static readonly int PageNumberLowerLimit = 1;
            public static readonly int PageNumberUpperLimit = 25;
            public static readonly int PageSizeLowerLimit = 1;
            public static readonly int PageSizeUpperLimit = 100;

            public static readonly int PageNumberDefaultValue = 1;
            public static readonly int PageSizeDefaultValue = 25;
        }
    }
}
