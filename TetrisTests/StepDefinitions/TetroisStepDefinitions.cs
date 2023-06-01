using TetrisLib;

namespace TetrisTests.StepDefinitions
{
    [Binding]
    public sealed class TetroisStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        ScenarioContext _scenarioContext;

        public TetroisStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"there is a '([^']*)' tetromino")]
        public void GivenThereIsATetromino(string shape)
        {
            ITetroid tetroid = null;
            if(shape == "T")
            {
                tetroid = new T();
            }
            else if(shape == "I")
            {
                tetroid = new I();
            }
            else if(shape == "O")
            {
                tetroid = new O();
            }
            _scenarioContext.Add("tetroid", tetroid);
        }


        [When(@"the tetromino moves right")]
        public void WhenTheTetrominoMovesRight()
        {
            _scenarioContext.Get<ITetroid>("tetroid").MoveRight();
        }

        [Then(@"the tetrominos x position should be (.*)")]
        public void ThenTheTetrominosXPositionShouldBe(int p0)
        {
            _scenarioContext.Get<ITetroid>("tetroid").XPos.Should().Be(p0);
        }

        [When(@"the tetromino moves left")]
        public void WhenTheTetrominoMovesLeft()
        {
            _scenarioContext.Get<ITetroid>("tetroid").MoveLeft();
        }

        [When(@"it rotates clockwise")]
        public void WhenItRotatesClockwise()
        {
            _scenarioContext.Get<ITetroid>("tetroid").RotateRight();
        }

        [When(@"it rotates counterclockwise")]
        public void WhenItRotatesCounterclockwise()
        {
            _scenarioContext.Get<ITetroid>("tetroid").RotateLeft();
        }


        [Then(@"the shape of the tetromino should look like")]
        public void ThenTheShapeOfTheTetrominoShouldLookLike(string multilineText)
        {
            _scenarioContext.Get<ITetroid>("tetroid").ToString().Should().Be(multilineText);
        }

        [Given(@"there is a board")]
        public void GivenThereIsABoard()
        {
            _scenarioContext.Add("board", new Board());
        }

        [When(@"the tetromino gets added to the board")]
        public void WhenTheTetrominoGetsAddedToTheBoard()
        {
            Board b = _scenarioContext.Get<Board>("board") + _scenarioContext.Get<ITetroid>("tetroid");
            _scenarioContext.Remove("board");
            _scenarioContext.Add("board", b);
        }

        [Then(@"the board should look like")]
        public void ThenTheBoardShouldLookLike(string multilineText)
        {
            _scenarioContext.Get<Board>("board").ToString().Should().Be(multilineText);
        }

        [When(@"we simulate the tetroid in hand spining counterclockwise on the board")]
        public void WhenWeSimulateTheTetroidInHandSpiningCounterclockwiseOnTheBoard()
        {
            removeHeldTetrominoFromBoard();
            WhenItRotatesCounterclockwise();
            WhenTheTetrominoGetsAddedToTheBoard();
        }

        private void removeHeldTetrominoFromBoard()
        {
            Board b = _scenarioContext.Get<Board>("board") - _scenarioContext.Get<ITetroid>("tetroid");
            _scenarioContext.Remove("board");
            _scenarioContext.Add("board", b);
        }

        [When(@"we simulate the tetroid falling (.*) space down")]
        public void WhenWeSimulateTheTetroidFallingSpaceDown(int p0)
        {
            removeHeldTetrominoFromBoard();
            _scenarioContext.Get<ITetroid>("tetroid").MoveDown();
            WhenTheTetrominoGetsAddedToTheBoard();
        }

        [When(@"the held piece stops where it is on the board")]
        public void WhenTheHeldPieceStopsWhereItIsOnTheBoard()
        {
            WhenTheTetrominoGetsAddedToTheBoard();
            _scenarioContext.Remove("tetroid");
        }

        [When(@"the tetromino moves right (.*) times")]
        public void WhenTheTetrominoMovesRightTimes(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                WhenTheTetrominoMovesRight();
            }
        }

        [Then(@"the board should recognize there is a line to remove")]
        public void ThenTheBoardShouldRecognizeThereIsALineToRemove()
        {
            _scenarioContext.Get<Board>("board").FindNthFilledLine(0).Should().NotBe(-1);
        }


    }
}