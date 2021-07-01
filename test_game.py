import pytest
from game import Game

@pytest.fixture
def game():
	return Game()

def test_game_instance(game):
	assert game

def test_roll_all_zeros(game):
	for _ in range(20):
		game.roll(0)
	score = game.get_score()
	assert score == 0


def test_roll_all_twos(game):
	for i in range(20):
		game.roll(2)
	assert game.get_score() == 40

def test_roll_score_58(game):
	for i in range(20):
		if i < 2:
			game.roll(2)
		else:
			game.roll(3)
	assert game.get_score() == 58

def test_roll_2_4_alternatives(game):
	for i in range(20):
		if (i%2 == 0):
			game.roll(2)
		elif (i%2 > 0):
			game.roll(5)
	assert game.get_score() == 70

def test_roll_first_frame_spare(game):
	for i in range(20):
		if (i < 2):
			game.roll(5)
		else:
			game.roll(2)

	assert game.get_score() == 48
