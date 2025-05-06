using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter.Config;

namespace QAAssignment.Utility
{
    public class ExtentReport
    {

        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;

        public static String testResPath = "C:\\Screenshots\\VåraSidor\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
        public static String testResultPath = IsPathExist(testResPath);

        public static void ExtentReportInit()
        {
            Console.WriteLine("Inside Extent Report");
            var htmlReporter = new ExtentSparkReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            //htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Youtube");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            Console.WriteLine("Inside Extent Report  teardown");
            _extentReports.Flush();
        }

        public string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }

        public static string IsPathExist(string testResultPath)
        {
            if (!Directory.Exists(testResultPath))
            {
                Directory.CreateDirectory(testResultPath);
            }
            return testResultPath;
        }

    }
}
