using System;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using QAAssignment.Pages;
using Reqnroll;

namespace QAAssignment.StepDefinitions
{
    [Binding]
    public class SpinWithValidBetStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage page;
        private int initialBalance;
        private int betAmount;
        private int sleepTime = 1000;

        public SpinWithValidBetStepDefinitions(IWebDriver driver, LoginPage page)
        {
            this.driver = driver;
            this.page = page;
        }

        [Given(@"Navigate to the slot game page")]
        public void GivenINavigateToTheSlotGamePage()
        {
            string url = "http://127.0.0.1:8000";
            page.LoadPage(url);
            Thread.Sleep(sleepTime);
        }

        [Given(@"Enter a bet of (.*)")]
        public void GivenIEnterABetOf(int Bet)
        {
            betAmount = Bet;
            var balanceText = driver.FindElement(By.Id("coins")).Text;
            initialBalance = int.Parse(balanceText);

            var betInput = driver.FindElement(By.Id("bet"));
            betInput.Clear();
            betInput.SendKeys(betAmount.ToString());
        }

        [When(@"Click the spin button and chek the initial balamce is decresed")]
        public void WhenIClickTheSpinButton()
        {
            driver.FindElement(By.Id("spinBtn")).Click();
            var balanceText = driver.FindElement(By.Id("coins")).Text;
            int newBalance = int.Parse(balanceText);
            Assert.AreEqual(initialBalance - betAmount, newBalance, "Balance did not decrease correctly.");
            Thread.Sleep(sleepTime * 3); // wait for spin animation to finish
        }


        [Then(@"The result should reflect the correct amount and message")]
        public void ThenTheResultShouldReflectTheCorrectAmountAndMessage()
        {
            // Get final balance
            int finalBalance = int.Parse(driver.FindElement(By.Id("coins")).Text);
            int expectedBalance = initialBalance - betAmount;

            // Read reel symbols
            string s1 = driver.FindElement(By.Id("reel1")).Text.Trim();
            string s2 = driver.FindElement(By.Id("reel2")).Text.Trim();
            string s3 = driver.FindElement(By.Id("reel3")).Text.Trim();

            int win = 0;
            string expectedMessage;

            if (s1 == s2 && s2 == s3)
            {
                win = betAmount * 10;
                expectedMessage = $"🎉 JACKPOT! +{win} coins!";
            }
            else if (s1 == s2 || s2 == s3 || s1 == s3)
            {
                win = betAmount * 2;
                expectedMessage = $"👍 Nice match! +{win} coins.";
            }
            else
            {
                expectedMessage = "😢 No match, try again!";
            }

            expectedBalance += win;
            Assert.AreEqual(expectedBalance, finalBalance, $"Expected balance: {expectedBalance}, Actual: {finalBalance}. Reels: [{s1}, {s2}, {s3}], Win: {win}");// Assert balance

            var actualMessage = driver.FindElement(By.Id("message")).Text.Trim();
            Assert.AreEqual(expectedMessage, actualMessage, $"Expected message: '{expectedMessage}', but got: '{actualMessage}'");// Assert message
        }
    }
}
