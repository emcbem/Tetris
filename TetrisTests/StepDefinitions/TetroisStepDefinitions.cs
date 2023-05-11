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

        [Given(@"there is a T tetromino")]
        public void GivenThereIsATTetromino()
        {
            _scenarioContext.Add("tetroid", new T());
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

        [Then(@"the shape of the tetromino should look like")]
        public void ThenTheShapeOfTheTetrominoShouldLookLike(string multilineText)
        {
            _scenarioContext.Get<ITetroid>("tetroid").ToString().Should().Be(multilineText);
        }


    }
}