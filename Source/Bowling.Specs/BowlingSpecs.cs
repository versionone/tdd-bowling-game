using System;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_everything_is_wired_up : concerns
	{
		
		[Specification]
		public void it_works()
		{
		    

		    true.should_be_true();
		}
	}
}