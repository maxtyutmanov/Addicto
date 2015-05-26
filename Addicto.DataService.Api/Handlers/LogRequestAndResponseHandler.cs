using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Addicto.DataService.Api.Handlers
{
    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(LogRequestAndResponseHandler));

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string requestStr = request.ToString();

            _log.Debug(requestStr);

            return base.SendAsync(request, cancellationToken);
        }
    }
}