using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace akqa.Models
{
	public class ApiResult
	{
		public string Name { get; set; }
		public string Amount { get; set; }
		public string AmountInWords { get; set; }
		public string ExtraMessage { get; set; }
	}
}