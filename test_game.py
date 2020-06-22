import pytest
from game import Game

@pytest.fixture
def game():
	return Game()

def test_game_instance(game):
	assert game

def test_all_gutter_balls(game):
	for i in range(20):
		game.roll(0)
	assert game.score() == 0

def test_all_two_balls(game):
	for i in range(20):
		game.roll(2)
	assert game.score() == 40

def test_all_twos_and_threes(game):
	game.roll(2)
	game.roll(2)
	for i in range(18):
		game.roll(3)
	assert game.score() == 58

def test_all_twos_and_fives(game):
	for i in range(10):
		game.roll(2)
		game.roll(5)
	assert game.score() == 70

def test_one_spare(game):
	game.roll(2)
	game.roll(8)
	for i in range(18):
		game.roll(2)
	assert game.score() == 48

def test_two_spares(game):
	for i in range(2):
		game.roll(2)
		game.roll(8)
	for i in range(16):
		game.roll(2)
	assert game.score() == 56

def test_too_many_rolls(game):
	for i in range(22):
		game.roll(2)
	assert game.score() == 40

def test_first_strike(game):
	game.roll(10)
	for i in range(18):
		game.roll(2)
	assert game.score() == 50
