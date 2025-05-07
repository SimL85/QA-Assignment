# QAAssignment
✅ Prerequisites
Before running the project, make sure you have the following tools installed and set up:

🧰 Development Environment
.NET SDK 8.0
Download here
https://dotnet.microsoft.com/en-us/download

IDE:
Microsoft Visual Studio Community 2022 (64-bit) - Current Version 17.13.6

Chrome Browser (latest version, used for Selenium WebDriver tests) the driver is inside the solution


📦 NuGet Packages (Installed via .csproj)

These are restored automatically when you build the solution:

Selenium.WebDriver

Selenium.Support

Reqnroll.NUnit

NUnit & NUnit3TestAdapter

Microsoft.NET.Test.Sdk

ExtentReports

🔧 Installing Reqnroll Extension in Visual Studio 2022
Open Visual Studio 2022

Go to the menu:
Extensions → Manage Extensions

In the search bar, type:
Reqnroll

Click Download on the Reqnroll for Visual Studio extension.

Close Visual Studio — the installer will launch and apply the extension.

Reopen Visual Studio. You should now see full support for .feature files and step definitions.

## Running the Test Suite

To run all tests together, follow these steps:

1. Open the solution in Visual Studio 2022.
2. Ensure that the required dependencies are restored by building the solution (`Ctrl+Shift+B`).
3. Open the __Test Explorer__ window by navigating to __Test > Test Explorer__.
4. Click on the "Run All" button in the __Test Explorer__ to execute all tests.
![image](https://github.com/user-attachments/assets/a2b3b90a-ca88-4693-b18a-459c5fa6a93b)


## Running Individual Tests

To run a specific test:

1. Open the __Test Explorer__ in Visual Studio 2022.
2. Locate the test you want to run in the list of tests.
3. Right-click on the test and select "Run"
<img width="465" alt="image" src="https://github.com/user-attachments/assets/4e3f63ea-0f58-459a-b82a-73f06f6ac4fb" />


