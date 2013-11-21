using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public class FizzBuzz
	{
		public string GetResult(int value)
		{
			string returnVal = value.ToString();
			if (value % 3 == 0 && value % 5 != 0)
				returnVal = "fizz";
			if (value % 5 == 0 && value % 3 != 0)
				returnVal = "buzz";
			if (value % 5 == 0 && value % 3 == 0)
				returnVal = "fizzbuzz";
			return returnVal;
		}
	}
}
