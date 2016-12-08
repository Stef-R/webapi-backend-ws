using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Backend.WebApi
{
    public class VerisionCheckFilter : IActionFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
                //throw new NotImplementedException();
            }
        }

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(
            HttpActionContext actionContext, 
            CancellationToken cancellationToken, 
            Func<Task<HttpResponseMessage>> continuation)
        {
            //HttpResponseMessage response = null;
            // do
            Debug.WriteLine("før kald");
            var header = actionContext.Request.Headers.FirstOrDefault(h => h.Key =="X-Version");



            if (header.Key != null)
            {
                var version = header.Value.FirstOrDefault();
                if (version == "42")
                {
                    Debug.WriteLine("EQ 42 true");

                }

            }
                    HttpResponseMessage response = await continuation();
            if (true)
            {
            }



            //do 

            Debug.WriteLine("efter kald");
            return response;


            // throw new NotImplementedException();
        }
    }
}