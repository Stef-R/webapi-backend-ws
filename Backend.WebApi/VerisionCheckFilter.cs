using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

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
            HttpResponseMessage response = null;


            if (header.Key != null)
            {
                var version = header.Value.FirstOrDefault();
                if (version == "42")
                {
                    Debug.WriteLine("EQ 42 true");
                    response = await continuation();

                }

            }
            if (response == null)
            {
                var result = new StatusCodeResult((HttpStatusCode)418, actionContext.Request);
                response = await result.ExecuteAsync(cancellationToken);
            }



            //do 

            Debug.WriteLine("efter kald");
            return response;


            // throw new NotImplementedException();
        }
    }
}