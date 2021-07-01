class Game:

	def __init__(self):
		self.myscore = 0
		self.spare = False
		self.try_num_arr = []

	def roll(self, roll):
		self.try_num_arr.append(roll)


	def get_score(self):
		for index in range(len(self.try_num_arr)):
			ms = self.try_num_arr[index]

			if (index == 0) or ( index == 1):
				self.myscore += ms

			elif(index == 2):
				if((self.try_num_arr[0] + self.try_num_arr[1]) >= 10):
				    self.myscore += ms*2
				else:
					self.myscore += ms

			else:

				self.myscore += ms

		return self.myscore


