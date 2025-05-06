using System;
using NUnit.Framework;
using OpenQA.Selenium;
using QAAssignment.Pages;
using Reqnroll;

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

        [Then(@"The bet field should (.*)")]
        public void ThenTheBetFieldShould(string result)
        {
            //betInput = driver.FindElement(By.Id("bet"));
            //string value = betInput.GetAttribute("value");


            //Thread.Sleep(sleepTime);
            //if (result == "be accepted")
            //{
            //    Thread.Sleep(sleepTime / 2);
            //    bool isNumeric = int.TryParse(value, out int num); // Should be a positive integer and retained
            //    Thread.Sleep(sleepTime / 2);
            //    Assert.IsTrue(isNumeric && num > 0, $"Expected accepted numeric input, but got: '{value}'");
            //}
            //else if (result == "be rejected")
            //{
            //    Thread.Sleep(sleepTime / 2);
            //    bool isNumeric = int.TryParse(value, out int num); // Should be empty or invalid (non-positive or not a number)
            //    Thread.Sleep(sleepTime / 2);
            //    Assert.IsTrue(string.IsNullOrEmpty(value) || !isNumeric || num <= 0, $"Expected rejected input, but field contains: '{value}'");
            //}
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            bool isValid = (bool)js.ExecuteScript("return document.getElementById('bet').checkValidity();");
            Thread.Sleep(sleepTime / 2);
            string betValue = (string)js.ExecuteScript("return document.getElementById('bet').value;");

            Thread.Sleep(sleepTime);

            if (result == "be accepted")
            {
                Thread.Sleep(sleepTime / 2);
                bool isNumeric = int.TryParse(betValue, out int num); // Should be a positive integer and retained
                Thread.Sleep(sleepTime / 2);
                Assert.IsTrue(isNumeric && num > 0, $"Expected accepted numeric input, but got: '{betValue}'");
            }
            else if (result == "be rejected")
            {
                Thread.Sleep(sleepTime / 2);
                bool isNumeric = int.TryParse(betValue, out int num); // Should be empty or invalid (non-positive or not a number)
                Thread.Sleep(sleepTime / 2);
                Assert.IsTrue(string.IsNullOrEmpty(betValue) || !isNumeric || num <= 0,
                    $"Expected rejected input, but field contains: '{betValue}'");
            }
        }
    }
}
