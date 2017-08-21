using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ValueProviders;
 
namespace Discover_WebAPI.Models
{
    public class HeaderValueFactory : ValueProviderFactory
    {

        public override IValueProvider GetValueProvider(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            return new HeaderValueProvider(actionContext.Request.Headers);
        }
    }
}
