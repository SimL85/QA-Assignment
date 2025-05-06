using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QAAssignment.Utility
{
    public class BrowserUtilities
    {
        public static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        private static String browser;
        private static String url;

        private static String driverPath = "C:\\TFS\\Test\\Test_automation\\drivers";
        private static String defaultBrowser = "chrome";

        public static IWebDriver GetBrowser(BrowserInfo browserInfo, String url)
        {
            if (browserInfo.browser == null)
            {
                browserInfo.browser = defaultBrowser;
            }

            BrowserUtilities.url = url;

            
            LoadBrowser(browserInfo);
        
            return driver.Value;
        }
        private static void LoadBrowser(BrowserInfo browserInfo)
        {
            switch (browserInfo.browser)
            {

                case "chrome":
                    InitializeChrome();
                    break;
                case "H_chrome":
                    InitializeChromeHeadless();
                    break;

                default:
                    throw new AssertionException("Browser : " + browser + " is not correct");
            }
        }

        private static void InitializeChrome()
        {
            // NOTE: Download and add ChromeDriver.exe in a %PATH% folder
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--start-maximized");

            options.AddArguments(new List<string>(){
                "--start-maximized",
                "--disable-search-engine-choice-screen",
                "--disable-cookies",
                //"--force-device-scale-factor=0.4"
            });


            driver.Value = new ChromeDriver(driverPath, options);

            // Configure implicit wait
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        private static void InitializeChromeHeadless()
        {
            // NOTE: Download and add ChromeDriver.exe in a %PATH% folder
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(new List<string>(){
                "--headless",
                "--window-size=1920,1080",
                "--force-device-scale-factor=0.5"
            });

            driver.Value = new ChromeDriver(driverPath, options);

            // Configure implicit wait
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// Struct containing data about current browser and OS in test
        /// </summary>
        public struct BrowserInfo
        {
            public string browser;
            public string remoteComputer;
            public string deviceID;
            public string env;
        }
    }
}
