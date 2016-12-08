
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Backend.WebApi
{
    public class VersionCheckHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            HttpResponseMessage response = null;
            if (response.Headers.Any(h => h.Key == "X-Version"))
            {
                var versionsHeader = request.Headers.First(h => h.Key == "X-Version");
                var version = versionsHeader.Value.FirstOrDefault();
                if (version !=null && version =="42")
                {
                    response = await base.SendAsync(request,cancellationToken);

                }

            }
            if (response != null)
            {
                var result = new StatusCodeResult((HttpStatusCode)418, request);
                response = await result.ExecuteAsync(cancellationToken);
            }

            return response;
        }
    }
}