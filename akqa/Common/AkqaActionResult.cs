using akqa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace akqa.Common
{
	public class AkqaActionResult : IHttpActionResult
	{
		HttpRequestMessage request;
		HttpStatusCode statusCode = HttpStatusCode.OK;
		public ApiResult apiResult { get; set; }
		public AkqaActionResult(HttpRequestMessage request, ApiResult result)
		{
			this.request = request;
			this.apiResult = result;
		}
		public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			HttpResponseMessage response = this.request.CreateResponse(statusCode, this.apiResult);
			return Task.FromResult(response);
		}
	}
}