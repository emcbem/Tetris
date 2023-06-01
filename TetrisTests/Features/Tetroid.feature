Feature: Tetroid
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](TetrisTests/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: A tetromino moves
	When there is a 'T' tetromino
	When the tetromino moves right
	Then the tetrominos x position should be 1
	When the tetromino moves left
	Then the tetrominos x position should be 0
	When the tetromino moves left
	Then the tetrominos x position should be 0

Scenario: A T Tetronimo rotates clockwise correctly
	When there is a 'T' tetromino
	When it rotates clockwise
	Then the shape of the tetromino should look like
	"""
	01
	11
	01
	"""
	When it rotates clockwise
	Then the shape of the tetromino should look like
	"""
	010
	111
	"""
	When it rotates clockwise
	Then the shape of the tetromino should look like
	"""
	10
	11
	10
	"""
	When it rotates clockwise
	Then the shape of the tetromino should look like
	"""
	111
	010
	"""

Scenario: A T Tetronimo rotates counterclockwise correctly
	When there is a 'T' tetromino
	When it rotates counterclockwise
	Then the shape of the tetromino should look like
	"""
	10
	11
	10
	"""
	When it rotates counterclockwise
	Then the shape of the tetromino should look like
	"""
	010
	111
	"""
	When it rotates counterclockwise
	Then the shape of the tetromino should look like
	"""
	01
	11
	01
	"""
	When it rotates counterclockwise
	Then the shape of the tetromino should look like
	"""
	111
	010
	"""

Scenario: A I Tetromino rotates counterclockwise correctly
	When there is a 'I' tetromino
	When it rotates counterclockwise
	Then the shape of the tetromino should look like
	"""
	1111
	"""
	When it rotates counterclockwise
	Then the shape of the tetromino should look like
	"""
	1
	1
	1
	1
	"""
	When it rotates counterclockwise
	Then the shape of the tetromino should look like
	"""
	1111
	"""
	When it rotates counterclockwise
	Then the shape of the tetromino should look like
	"""
	1
	1
	1
	1
	"""

Scenario: A tetromino is on the board
	When there is a 'T' tetromino
	Given there is a board
	When the tetromino gets added to the board
	Then the board should look like
	"""
	1110000000
	0100000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	"""
	When we simulate the tetroid in hand spining counterclockwise on the board
	Then the board should look like
	"""
	1000000000
	1100000000
	1000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	"""
	When we simulate the tetroid falling 1 space down
	Then the board should look like
	"""
	0000000000
	1000000000
	1100000000
	1000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	0000000000
	"""
	Scenario: Clearing a line
	Given there is a board
	When there is a 'I' tetromino
	When it rotates counterclockwise
	When the held piece stops where it is on the board
	When there is a 'I' tetromino
	When it rotates counterclockwise
	When the tetromino moves right
	When the tetromino moves right
	When the tetromino moves right
	When the tetromino moves right
	When the held piece stops where it is on the board
	When there is a 'O' tetromino
	When the tetromino moves right 8 times
	Then the board should recognize there is a line to remove