using System;
using NUnit.Framework;
using OpenQA.Selenium;
using QAAssignment.Pages;
using Reqnroll;
using Reqnroll.CommonModels;

namespace QAAssignment.StepDefinitions
{
    [Binding]
    public class FieldValidationBetFieldStepDefinitions
    {
        private IWebDriver driver;
        private IWebElement betInput;
        private int sleepTime = 1000;
        public FieldValidationBetFieldStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        [When(@"Enter (.*) in the bet field")]
        public void WhenIEnterInTheBetField(string input)
        {
            betInput = driver.FindElement(By.Id("bet"));
            Thread.Sleep(sleepTime / 2);
            betInput.Clear();
            Thread.Sleep(sleepTime / 2);
            betInput.SendKeys(input);
            Thread.Sleep(sleepTime / 2);
        }

        [Then(@"The bet field should (.*) and the alert should not be showed")]
        [Then(@"The bet field should (.*) and the alert should be showed in case to be rejected")]
        public void ThenTheBetFieldShould(string result)
        {
            betInput = driver.FindElement(By.Id("bet"));
            string value = betInput.GetAttribute("value");

            driver.FindElement(By.Id("spinBtn")).Click(); // Click the spin button
                                                          
            Thread.Sleep(sleepTime);

            if (result == "be accepted")
            {
                var messageElement = driver.FindElement(By.Id("message"));// Check message content
                string messageText = messageElement.Text;
                Thread.Sleep(sleepTime / 2);
                bool isNumeric = int.TryParse(value, out int num); // Should be a positive integer and retained
                Thread.Sleep(sleepTime / 2);
                Assert.IsTrue(isNumeric && num > 0, $"Expected accepted numeric input, but got: '{value}'");
                Assert.IsFalse(messageText.Contains(" Enter a valid bet amount.") || messageText.Contains("Not enough coins!"), $"Expected error message to appear, but got: '{messageText}'");
            }

            if (result == "be rejected")
            {
                IAlert alert = driver.SwitchTo().Alert(); 
                string alertText = alert.Text; // Check alert text
                Thread.Sleep(sleepTime / 2);
                bool isNumeric = int.TryParse(value, out int num);            
                Assert.IsTrue(string.IsNullOrEmpty(value) || !isNumeric || num <= 0, $"Expected rejected input, but field contains: '{value}'");
                Assert.IsTrue(alertText.Contains("Enter a valid bet amount") || alertText.Contains("Not enough coins"), $"Expected alert with rejection message, but got: '{alertText}'");
            }
        }
    }
}
