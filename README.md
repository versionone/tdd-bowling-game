# TDD Bowling Game
An example of doing Test-Driven Development using Bowling as the domain.

## Getting Started

1. Ensure `python` and `pip` are in your PATH.  In a Windows MinGW environment with a Python 2.7 installation, this can be accomplished with:

	```bash
	export PATH="$PATH:/c/Python27:/c/Python27/Scripts"
	```

1. Install packages:

	```bash
	pip install -r requirements.txt
	```

1. Verify your environment is working:

	```bash
	pytest
	```

## The game to be played
Below are some scenarios we can use to drive the development of the game.

* when rolling all gutter balls, the score is 0.
* when rolling all 2s, the score is 40.
* when the first 2 rolls are 2 and the rest are 3, the score is 58.
* when rolling alternating 2s and 5s, the score 70.
* when the first frame is a spare and the remaining rolls are all 2, the score is 48.
* when the first 2 frames are spare (as 2,8) and the rest score 2, the score is 56.
* when 10 frames have been bowled, don't allow any more to be bowled.
* when the first frame is a strike and the rest score 2, the score is 50.
* when the first 2 frames are strikes and the rest score 2, the score is 68.
* when rolling a perfect game, the score is 300.
* when rolling alternate strikes and spares, the score is 200.

### Thanks
A special thanks to [Ron Jeffries](http://xprogramming.com/articles/miningbowling/) 
for the original idea, and [Cory Foy](http://blog.coryfoy.com/2006/08/tdd-bowling-game-part-1/) 
for pushing it further.
