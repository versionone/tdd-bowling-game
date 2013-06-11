using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Specs.Infrastructure;
using MbUnit.Framework;

namespace Bowling.Specs
{
	public class fizz_buzzTests : concerns
	{
		private fizz_buzz MyFizzBuzz;

		[Specification]
		public void specify_something()
		{
			// for numbers 1 through 100...
			// if a number is divisible by 3, print 'fizz'
			// if a number is divisible by 5, print 'buzz'
			// if a number is dividible by both 3 and 5, print 'fizzbuzz'

		}

		[SetUp]
		public void Init()
		{
			MyFizzBuzz = new fizz_buzz();
		}

		[Test]
		public void fizzbuzzThingy_IsDivisibleByThree_ReturnsFizz()
		{
			int value = 6;
			Assert.AreEqual("fizz",MyFizzBuzz.Print(value));
		}

		[Test]
		public void fizzbuzzThingy_IsDivisibleByFive_ReturnsBuzz()
		{
			int value = 10;
			Assert.AreEqual("buzz", MyFizzBuzz.Print(value));
		}
		[Test]
		public void fizzbuzzThingy_IsNotDivisibleBy3Or5_ReturnsEmptyString()
		{
			int value = 11;
			Assert.AreEqual("", MyFizzBuzz.Print(value));
		}
		[Test]
		public void fizzbuzzThingy_IsDivisibleBy3And5_ReturnsFizzBuzz()
		{
			int value = 15;
			Assert.AreEqual("fizzbuzz", MyFizzBuzz.Print(value));
		}


	}

	public class fizz_buzz
	{

		public string Print(int value)
		{
			string output = "";

			if (value%3 == 0)
			{
				output =  "fizz";
			}
			if(value%5 == 0)
			{
				output += "buzz";
			}
			return output;
		}
	}
}
