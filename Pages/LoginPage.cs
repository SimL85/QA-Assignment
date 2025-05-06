using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using static QAAssignment.Utility.BrowserUtilities;

namespace QAAssignment.Pages
{
    public class LoginPage
    {
        private IWebDriver driver = null;
        private static WebDriverWait wait;
        private BrowserInfo browserInfo = new BrowserInfo();

        public LoginPage(IWebDriver webDriver)
        {
            Console.WriteLine("Page: LoginPage");
            driver = webDriver;
            // Configure explicit wait
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            // Configure implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void LoadPage(string url)
        {
            Console.Write("Load url" + url);
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
        } 
    }
}
