using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ValueProviders;
//using System.Web.ModelBinding;

namespace Discover_WebAPI.Models
{
    public class HeaderValueProvider : IValueProvider
    {

        public HttpRequestHeaders Header { get; set; }
        public HeaderValueProvider(HttpRequestHeaders header)
        {
            Header = header;
        }

        // The ContainsPrefix method is called to verify that the header contains the information that we need
        public bool ContainsPrefix(string prefix)
        {
            return Header.Any(s => s.Key.StartsWith(prefix));
        }


        // The GetValue method is called to extract the information from the header and to return it in a form of ValueProviderResult

         ValueProviderResult IValueProvider.GetValue(string key)
        {
            KeyValuePair<string, IEnumerable<string>> header = Header.FirstOrDefault(s => s.Key.StartsWith(key));
            string headervalue = string.Join(",", header.Value);
            return new ValueProviderResult(headervalue, headervalue, CultureInfo.InvariantCulture);
        }
    }
}
