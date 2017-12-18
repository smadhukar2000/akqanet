using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace akqa.Common
{
	public class HelperUtility : IHelperUtility
	{
		public string NumberToWord(string input)
		{
			string separator = " AND ";
			string strWords = string.Empty;
			bool isNegative = false;

			string decimals = "";

			// check if -ve input
			if (input[0] == '-')
			{
				isNegative = true;
				input = input.Substring(1);
			}

			// check fraction number
			if (input.Contains("."))
			{
				decimals = input.Substring(input.IndexOf(".") + 1);
				// remove decimal part from input
				input = input.Remove(input.IndexOf("."));
			}

			if (int.Parse(input) > 0)
			{
				// Convert input into words. save it into strWords
				strWords = Utility.GetNumberToWords(input) + "Dollars";
			}
			else
			{
				separator = string.Empty;
			}

			if (decimals.Length > 0 && int.Parse(decimals) > 0)
			{
				// case single digit after decimal
				if(decimals.Length == 1)
				{
					decimals += "0";
				}
				// if there is any decimal part convert it to words and add it to strWords.
				strWords += separator + Utility.GetNumberToWords(decimals) + "Cents";
			}

			return (isNegative == true ? "- " + strWords : strWords);
		}
	}
}