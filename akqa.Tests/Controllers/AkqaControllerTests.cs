using Microsoft.VisualStudio.TestTools.UnitTesting;
using akqa.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using akqa.Models;
using akqa.Common;
using Moq;

namespace akqa.Controllers.Tests
{
	[TestClass]
	public class AkqaControllerTests
	{
		Mock<IHelperUtility> _moqHelper = new Mock<IHelperUtility>();
		[TestMethod]
		public void ConvertNumbersReturnTypeTest()
		{
			string amount = "134.54";
			string name = "Subhash Madhukar";			
			AkqaController controller = new AkqaController();
			IHttpActionResult actionResult = controller.ConvertNumbers(name, amount);

			Assert.IsInstanceOfType(actionResult, typeof(AkqaActionResult));			
		}

		[TestMethod]
		public void GetAlwaysWordsTest()
		{
			string amount = "0";
			string words = "One Hundred Thirty Four Dollars AND Fifty Four Cents";
			_moqHelper.Setup(x => x.NumberToWord(It.IsAny<string>())).Returns(words);

			AkqaController controller = new AkqaController();
			string result = controller.GetAmountInWords(_moqHelper.Object, amount);

			Assert.AreEqual(words, result);
		}

		[TestMethod]
		public void GetExactContentTest()
		{
			string amount = "134.54";
			string name = "Subhash Madhukar";
			string words = "One Hundred Thirty Four Dollars AND Fifty Four Cents";
			
			AkqaController controller = new AkqaController();
			var response = controller.ConvertNumbers(name, amount);

			AkqaActionResult result = response as AkqaActionResult;

			Assert.AreEqual(words, result.apiResult.AmountInWords);
		}

		[TestMethod]
		public void AmountZeroAndNameEmptyTest()
		{
			string amount = "0";
			string name = "";
			string words = "";

			AkqaController controller = new AkqaController();
			var response = controller.ConvertNumbers(name, amount);

			AkqaActionResult result = response as AkqaActionResult;

			Assert.AreEqual(words, result.apiResult.AmountInWords);
		}

	}
}