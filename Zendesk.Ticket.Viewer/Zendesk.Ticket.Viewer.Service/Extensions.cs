using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Zendesk.Ticket.Viewer.Service
{
    public static class Extensions
    {
        public static NameValueCollection ToNameValueCollection(this string url)
        {
            if (url != null)
            {
                var idx = url.IndexOf('?');
                if (idx >= 0)
                {
                    url = url.Substring(idx + 1);
                }
                var query = QueryHelpers.ParseNullableQuery(url);
                if (query != null)
                {
                    return query.AsNameValueCollection();
                }
            }

            return new NameValueCollection();
        }

        public static NameValueCollection AsNameValueCollection(this IDictionary<string, StringValues> collection)
        {
            var nv = new NameValueCollection();

            foreach (var field in collection)
            {
                nv.Add(field.Key, field.Value.First());
            }

            return nv;
        }

        public static int TryParseInt(this NameValueCollection parameter, string key)
        {
            int.TryParse(parameter.Get(key), out var value);
            return value;
        }
    }
}
