using System;
using Reqnroll;

namespace QAAssignment.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        [Given("the second number is {int}")]
        public void GivenTheSecondNumberIs(int p0)
        {
            throw new PendingStepException();
        }
    }
}
