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

        private static string _screenshotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Screenshots");
        private static string _reportPath;

        public static void ExtentReportInit()
        {
            Console.WriteLine("Initializing Extent Report...");

            _reportPath = EnsureDirectoryExists(_screenshotPath);

            var htmlReporter = new ExtentSparkReporter(_reportPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Youtube");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            Console.WriteLine("Flushing Extent Report...");
            _extentReports?.Flush();
        }

        public static string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            try
            {
                ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
                Screenshot screenshot = takesScreenshot.GetScreenshot();
                string fileName = $"{scenarioContext.ScenarioInfo.Title}_{DateTime.Now:yyyyMMddHHmmss}.png";
                string fullPath = Path.Combine(_reportPath, fileName);
                screenshot.SaveAsFile(fullPath);
                return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error taking screenshot: {ex.Message}");
                return null;
            }
        }

        private static string EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
    }
}