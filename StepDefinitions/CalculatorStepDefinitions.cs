using System;
using OpenQA.Selenium;
using QAAssignment.Pages;
using Reqnroll;

namespace QAAssignment.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage page;

        public CalculatorStepDefinitions(IWebDriver driver, LoginPage page)
        {
            this.driver = driver;
            this.page = page;
        }

        [Given("the second number is")]
        public void GivenTheSecondNumberIs()
        {
            string url = "https://testportal.rd.sverigesakassor.net/";
            page.LoadPage(url);
        }
    }
}
