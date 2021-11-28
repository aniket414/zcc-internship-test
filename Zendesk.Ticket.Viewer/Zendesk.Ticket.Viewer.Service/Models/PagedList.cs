using System;
using System.Collections.Generic;

namespace Zendesk.Ticket.Viewer.Service
{
    public class PagedList<T> : List<T>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }
    }
}
