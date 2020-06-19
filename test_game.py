import pytest
from game import Game


@pytest.fixture
def game():
	return Game()


def test_game_instance(game):
	assert game


def test_bowl_all_zeros(game):
	for i in range(20):
		game.roll(0)
	assert game.tally_score() == 0


def test_bowl_all_twos(game):
	for i in range(20):
		game.roll(2)
	assert game.tally_score() == 40


def test_bowl_mostly_threes(game):
	for i in range(2):
		game.roll(2)
	for i in range(18):
		game.roll(3)
	assert game.tally_score() == 58


def test_bowl_two_then_five(game):
	for i in range(10):
		game.roll(2)
		game.roll(5)
	assert game.tally_score() == 70


def test_first_frame_spare(game):
	game.roll(1)
	game.roll(9)
	for i in range(18):
		game.roll(2)
	assert game.tally_score() == 48


def test_first_two_frame_spare(game):
	for i in range(2):
		game.roll(2)
		game.roll(8)
	for i in range(16):
		game.roll(2)
	assert game.tally_score() == 56

def test_too_many_frames(game):
	for i in range(21):
		game.roll(1)
	assert game.tally_score() == 20

def test_first_frame_strike(game):
	game.roll(10)
	for i in range(18):
		game.roll(2)
	assert game.tally_score() == 50
