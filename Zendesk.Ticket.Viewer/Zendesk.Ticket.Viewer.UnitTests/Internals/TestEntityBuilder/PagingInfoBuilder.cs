using System;
using Zendesk.Ticket.Viewer.Service;

namespace Zendesk.Ticket.Viewer.UnitTests
{
    internal class PagingInfoBuilder
    {
        private PagingInfoRequest _pagingInfo;
        private int _pageNumber;
        private int _pageSize;

        internal PagingInfoBuilder()
        {
            _pageNumber = 1;
            _pageSize = 20;
        }

        internal PagingInfoRequest Build()
        {
            _pagingInfo = new PagingInfoRequest("pageNumber=1&pageSize=3");

            return _pagingInfo;
        }

        internal PagingInfoBuilder SetPageNumber(int pageNumber)
        {
            _pageNumber = pageNumber;
            return this;
        }

        internal PagingInfoBuilder SetPageSize(int pageSize)
        {
            _pageSize = pageSize;
            return this;
        }
    }
}
