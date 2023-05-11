Feature: Tetroid
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](TetrisTests/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: A tetromino moves
	Given there is a T tetromino
	When the tetromino moves right
	Then the tetrominos x position should be 1
	When the tetromino moves left
	Then the tetrominos x position should be 0
	When the tetromino moves left
	Then the tetrominos x position should be 0

Scenario: A tetronimo rotates correctly
	Given there is a T tetromino
	When it rotates clockwise
	Then the shape of the tetromino should look like
	"""
	001
	011
	001
	"""
	When it rotates clockwise
	Then the shape of the tetromino should look like
	"""
	000
	010
	111
	"""
	When it rotates clockwise
	Then the shape of the tetromino should look like
	"""
	100
	110
	100
	"""
	When it rotates clockwise
	Then the shape of the tetromino should look like
	"""
	111
	010
	000
	"""