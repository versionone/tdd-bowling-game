using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Specs.Infrastructure;

namespace Bowling.Specs
{
	class FrameSpecs
	{
		public class when_rolling_a_strike : concerns
		{
			private Frame _frame;

			protected override void context()
			{
				_frame = new Frame();
				_frame.Add_Roll(10);
			}

			[Specification]
			public void is_strike_should_be_true()
			{
				_frame.is_Strike().should_be_true();
			}

			[Specification]
			public void is_spare_should_be_false()
			{
				_frame.is_Spare().should_be_false();
			}
		}

		public class when_rolling_a_spare : concerns
		{
			private Frame _frame;

			protected override void context()
			{
				_frame = new Frame();
				_frame.Add_Roll(5);
				_frame.Add_Roll(5);
			}

			[Specification]
			public void is_strike_should_be_false()
			{
				_frame.is_Strike().should_be_false();
			}

			[Specification]
			public void is_spare_should_be_true()
			{
				_frame.is_Spare().should_be_true();
			}
		}

		public class when_adding_a_roll : concerns
		{
			private Frame _frame;

			protected override void context()
			{
				_frame = new Frame();
			}

			[Specification]
			public void first_roll_should_be_8()
			{
				_frame.Add_Roll(8);
				_frame.Get_First_Roll().should_equal(8);

			}

			[Specification]
			public void second_roll_should_be_2()
			{
				_frame.Add_Roll(2);
				_frame.Get_Second_Roll().should_equal(2);
			}
		}
	}
}
