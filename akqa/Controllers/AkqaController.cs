using akqa.Common;
using akqa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace akqa.Controllers
{
    public class AkqaController : ApiController
    {
		[HttpGet]
		[Route("api/akqa/convertnumbers/{name}/{amount}")]
		public IHttpActionResult ConvertNumbers(string name, string amount)
		{
			ApiResult result = new ApiResult {Name = name, Amount = amount, ExtraMessage = "Conversion Succesful"};
			try
			{
				result.AmountInWords = this.GetAmountInWords(new HelperUtility(), amount);
			}
			catch(Exception ex)
			{
				result.ExtraMessage = ex.Message;
			}
			return new AkqaActionResult(this.Request, result);		
		}

		[NonAction]
		public string GetAmountInWords(IHelperUtility helper, string amount)
		{
			return helper.NumberToWord(amount);
		}
	}
}
