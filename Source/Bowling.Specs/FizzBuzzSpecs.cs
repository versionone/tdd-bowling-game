using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	class when_1 : concerns<FizzBuzz>
	{
		private string _value;

		protected override void context()
		{
			_value = build_up().GetResult(1);
		}

		[Specification]
		public void result_is_1()
		{
			_value.should_equal("1");
		}
	}

	class when_6 : concerns<FizzBuzz>
	{
		private string _value;

		protected override void context()
		{
			_value = build_up().GetResult(6);
		}

		[Specification]
		public void result_is_fizz()
		{
			_value.should_equal("fizz");
		}
	}

	class when_10 : concerns<FizzBuzz>
	{
		private string _value;

		protected override void context()
		{
			_value = build_up().GetResult(10);
		}

		[Specification]
		public void result_is_buzz()
		{
			_value.should_equal("buzz");
		}
	}

	class when_15 : concerns<FizzBuzz>
	{
		private string _value;

		protected override void context()
		{
			_value = build_up().GetResult(15);
		}

		[Specification]
		public void result_is_fizzbuzz()
		{
			_value.should_equal("fizzbuzz");
		}
	}
}
