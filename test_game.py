import pytest
from game import Game

@pytest.fixture
def game():
	return Game()

def test_game_instance(game):
	assert game
