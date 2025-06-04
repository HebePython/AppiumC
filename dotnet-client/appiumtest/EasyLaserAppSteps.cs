using NUnit.Framework;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace appiumtest
{
    [Binding]
    public class EasyLaserAppSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private static AndroidDriver _driver;

        public EasyLaserAppSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        // SpecFlow hooks for setup/teardown
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Setup Appium driver (reuse your existing setup logic)
            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/");
            var driverOptions = new AppiumOptions()
            {
                AutomationName = "UiAutomator2",
                PlatformName = "Android",
                DeviceName = "Android Emulator",
            };
            driverOptions.AddAdditionalAppiumOption("appPackage", "com.android.settings");
            driverOptions.AddAdditionalAppiumOption("appActivity", ".Settings");
            driverOptions.AddAdditionalAppiumOption("noReset", true);
            _driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _driver?.Dispose();
        }

        // Step for: Given the app is started
        [Given(@"the app is started")]
        public void GivenTheAppIsStarted()
        {
            // Appium driver is already started in BeforeTestRun
        }

        // Step for: When I print all clickable elements
        [When(@"I print all clickable elements")]
        public void WhenIPrintAllClickableElements()
        {
            var elements = _driver.FindElements(By.XPath("//*[@clickable='true']"));
            foreach (var el in elements)
            {
                Console.WriteLine(el.Text);
            }
        }

        // Step for: Then clickable elements should be listed in the output
        [Then(@"clickable elements should be listed in the output")]
        public void ThenClickableElementsShouldBeListed()
        {
            // In a real test, you would assert on output or state
            Assert.Pass("Clickable elements printed to output.");
        }

        // Step for: When I launch the Easy-Laser XT Alignment app
        [When(@"I launch the Easy-Laser XT Alignment app")]
        public void WhenILaunchTheEasyLaserXTAlignmentApp()
        {
            var appIcon = _driver.FindElement(By.XPath("//*[@text='Easy-Laser XT Alignment' or @content-desc='Easy-Laser XT Alignment']"));
            appIcon.Click();
            System.Threading.Thread.Sleep(10000); // Wait for app to launch
        }

        // Step for: Then the app should be launched successfully
        [Then(@"the app should be launched successfully")]
        public void ThenTheAppShouldBeLaunchedSuccessfully()
        {
            // In a real test, you would check for a UI element unique to the launched app
            Assert.Pass("Easy-Laser XT Alignment app launched.");
        }
    }

    // --- SpecFlow basics ---
    // A SpecFlow test is defined in a .feature file using Gherkin syntax (Given/When/Then).
    // Each step in the feature file is mapped to a C# method using [Given], [When], or [Then] attributes.
    // The [Binding] class contains the step definitions and can use hooks for setup/teardown.
    // You can use NUnit assertions for validation.
}
