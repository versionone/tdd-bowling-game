using Bowling.Specs.Infrastructure;
using System;

namespace specs_for_fizzbuzz
{
	/// <summary>
	/// Let's code FizzBuzz!!!
	/// 
	/// Players generally sit in a circle. The player designated to go first says the number "1", and each player 
	/// thenceforth counts one number in turn. However, any number divisible by three is replaced by the word fizz 
	/// and any divisible by five by the word buzz. A player who hesitates or makes a mistake is eliminated from the game.	
	/// 
	/// Another variation is to replace numbers divisible by 3 with "Fizz", numbers divisible by 5 with "Buzz" (as per 
	/// the original), but in addition, replace numbers divisible by both 3 and 5 with "FizzBuzz". 
	/// 
	/// Write the test suite and implementation code demonstrating that any number given to a function 
	/// produces the correct translation (the number itself, Fizz, Buzz, or FizzBuzz), given the rules above. Enjoy!
	/// 	
	/// </summary>
	/// 
	public class FizzBuzzGame
	{
		public string Play(int number)
		{
			
			if(number % 3 == 0 && number % 5 == 0)
			{
				return "FizzBuzz";
			}

			if (number % 3 == 0 && number % 5 != 0)
			{
				return "Fizz";
			}
			if(number % 5 == 0 && number % 3 != 0)
			{
				return "Buzz";
			}
			else
			{
			 
				return number.ToString();
			}
		}
	}

	public class FizzBuzzTester : concerns
	{
		private FizzBuzzGame game = new FizzBuzzGame();

		protected override void context()
		{
		}
		
		[Specification]
		public void when_1_is_played_returns_1()
		{
			var number = 1;
			var result = game.Play(number);
			result.ShouldEqual(number.ToString());
		}

		[Specification]
		public void when_divisible_by_3_not_by_5()
		{
			var number = 9;
			var result = game.Play(number);
			result.ShouldEqual("Fizz");
		}
		
		[Specification]
		public void when_divisible_by_5_not_by_3()
		{
			var number = 10;
			var result = game.Play(number);
			result.ShouldEqual("Buzz");
		}

		[Specification]
		public void when_divisible_by_3_and_5()
		{
			var number = 15;
			var result = game.Play(number);
			result.ShouldEqual("FizzBuzz");
		}

	}	
}