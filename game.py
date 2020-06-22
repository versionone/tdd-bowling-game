class Game:

	def __init__(self):
		self.rolls = []

	def roll(self, roll_score):
		self.rolls.append(roll_score)

	def score(self):
		score = 0
		partial_score = 0
		for idx, roll in enumerate(self.rolls):
			partial_score += roll
			if (idx + 1) % 2 == 0:
				if partial_score == 10 and idx + 1 < len(self.rolls):
					partial_score += self.rolls[idx + 1]
				score += partial_score
				partial_score = 0
		return score
