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

        [Given(@"there is a '([^']*)' tetromino")]
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


    }
}