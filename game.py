class Game:
	def __init__(self):
		self.score = 0
		self.frames = [Frame()]

	def roll(self, num):
		self.frames[-1].update(num)
		if self.frames[-1].complete:
			self.frames.append(Frame())

	def tally_score(self):
		for i in range(0, 10):
			if self.frames[i].strike:
				self.score += self.frames[i].score + self.frames[i+1].score
			elif self.frames[i].spare:
				self.score += self.frames[i].score + self.frames[i + 1].rolls[0]
			else:
				self.score += self.frames[i].score
		return self.score


class Frame:
	def __init__(self):
		self.rolls = []
		self.complete = False
		self.spare = False
		self.strike = False
		self.score = 0

	def update(self, num):
		"check roll# -> Check if spare -> check if strike -> (mark complete?)"
		self.rolls.append(num)
		if len(self.rolls) == 2:
			self.complete = True
			if sum(self.rolls) == 10:
				self.spare = True
		else:
			if sum(self.rolls) == 10:
				self.complete = True
				self.strike = True
		self.score = sum(self.rolls)

