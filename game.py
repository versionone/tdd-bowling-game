class Game:

	MAX_FRAMES = 10
	SPARE = 10
	STRIKE = 10

	def __init__(self):
		self.frame_index = 0
		self.frames = {}

	def roll(self, roll_score):
		if self.frame_index not in self.frames:
			self.frames[self.frame_index] = []
		elif len(self.frames[self.frame_index]) == 2:
			self.frame_index += 1
			self.frames[self.frame_index] = []

		self.frames[self.frame_index].append(roll_score)

		if roll_score == self.STRIKE and len(self.frames[self.frame_index]) < 2:
			self.frame_index += 1

	def score(self):
		score = 0
		for frame_idx in self.frames:
			if frame_idx == self.MAX_FRAMES:
				break

			frame = self.frames[frame_idx]
			frame_sum = sum(frame)

			if len(frame) and frame[0] == self.STRIKE:
				# strike logic: add the value of the next two rolls
				if (frame_idx + 1) in self.frames:
					frame_sum += sum(self.frames[frame_idx + 1])
					if len(self.frames[frame_idx + 1]) < 2:
						if (frame_idx + 2) in self.frames and len(self.frames[frame_idx + 2]):
							frame_sum += self.frames[frame_idx + 2][0]
			elif frame_sum == self.SPARE:
				# spare logic: add the first roll of the next frame
				if (frame_idx + 1) in self.frames and len(self.frames[frame_idx + 1]):
					frame_sum += self.frames[frame_idx + 1][0]

			score += frame_sum

		return score
