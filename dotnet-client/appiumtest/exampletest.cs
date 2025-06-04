using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Interactions;

namespace appiumtest;

public class Tests
{
    private AndroidDriver _driver;

    [OneTimeSetUp]
    public void SetUp()
    {
        var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/");
        var driverOptions = new AppiumOptions()
        {
            AutomationName = AutomationName.AndroidUIAutomator2,
            PlatformName = "Android",
            DeviceName = "Android Emulator",
        };

        driverOptions.AddAdditionalAppiumOption("appPackage", "com.android.settings");
        driverOptions.AddAdditionalAppiumOption("appActivity", ".Settings");
        driverOptions.AddAdditionalAppiumOption("noReset", true);

        _driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _driver.Dispose();
    }

    [Test]
    public void TestPrintClickableElements()
    {
        var elements = _driver.FindElements(By.XPath("//*[@clickable='true']"));
        foreach (var el in elements)
        {
            Console.WriteLine(el.Text);
        }
    }

    [Test]
    public void TestLaunchEasyLaserApp()
    {
        // Press the app icon with text or content-desc 'Easy-Laser XT Alignment'
        var appIcon = _driver.FindElement(By.XPath("//*[@text='Easy-Laser XT Alignment' or @content-desc='Easy-Laser XT Alignment']"));
        appIcon.Click();
        // Wait a moment for the app to launch
        System.Threading.Thread.Sleep(10000);

    }

    [Test]
    public void TestClickFirstClickableElement()
    {
        // Find all clickable elements
        var elements = _driver.FindElements(By.XPath("//*[@clickable='true']"));
        Assert.IsTrue(elements.Count > 0, "No clickable elements found.");
        // Click the first clickable element
        elements[0].Click();
    }

    [Test]
    public void TestPrintAllElementTextsAndClasses()
    {
        var elements = _driver.FindElements(By.XPath("//*"));
        foreach (var el in elements)
        {
            Console.WriteLine($"Text: {el.Text}, Class: {el.GetAttribute("className")}, Displayed: {el.Displayed}");
        }
    }

    [Test]
    public void TestPrintAllButtons()
    {
        var buttons = _driver.FindElements(By.ClassName("android.widget.Button"));
        foreach (var btn in buttons)
        {
            Console.WriteLine($"Button: {btn.Text}, Displayed: {btn.Displayed}");
        }
    }

    [Test]
    public void TestPrintAllElementAttributes()
    {
        var elements = _driver.FindElements(By.XPath("//*"));
        foreach (var el in elements)
        {
            Console.WriteLine(
                $"Text: {el.Text}, " +
                $"Class: {el.GetAttribute("className")}, " +
                $"Displayed: {el.Displayed}, " +
                $"ContentDesc: {el.GetAttribute("content-desc")}, " +
                $"ResourceId: {el.GetAttribute("resource-id")}"
            );
        }
    }
    [Test]
    public void TestPrintAllContentDescValues()
    {
        var elements = _driver.FindElements(By.XPath("//*[@content-desc]"));
        foreach (var el in elements)
        {
            Console.WriteLine($"ContentDesc: '{el.GetAttribute("content-desc")}'");
        }
    }
    

    [Test]
    public void TestTapVibrationButtonByCoordinates()
    {
        int x = 150; // Replace with actual x coordinate for the VIBRATION button
        int y = 250; // Replace with actual y coordinate for the VIBRATION button

        var pointer = new OpenQA.Selenium.Interactions.PointerInputDevice(OpenQA.Selenium.Interactions.PointerKind.Touch);
        var sequence = new OpenQA.Selenium.Interactions.ActionSequence(pointer, 0);
        sequence.AddAction(pointer.CreatePointerMove(OpenQA.Selenium.Interactions.CoordinateOrigin.Viewport, x, y, TimeSpan.Zero));
        sequence.AddAction(pointer.CreatePointerDown(0)); // 0 for touch contact
        sequence.AddAction(pointer.CreatePointerUp(0));
        _driver.PerformActions(new List<OpenQA.Selenium.Interactions.ActionSequence> { sequence });
    }

    [Test]
    public void TestTapMiddleOfScreen()
    {
        // Get screen size
        var size = _driver.Manage().Window.Size;
        int x = size.Width / 3;
        int y = size.Height / 2;

        var pointer = new OpenQA.Selenium.Interactions.PointerInputDevice(OpenQA.Selenium.Interactions.PointerKind.Touch);
        var sequence = new OpenQA.Selenium.Interactions.ActionSequence(pointer, 0);
        sequence.AddAction(pointer.CreatePointerMove(OpenQA.Selenium.Interactions.CoordinateOrigin.Viewport, x, y, TimeSpan.Zero));
        sequence.AddAction(pointer.CreatePointerDown(0));
        sequence.AddAction(pointer.CreatePointerUp(0));
        _driver.PerformActions(new List<OpenQA.Selenium.Interactions.ActionSequence> { sequence });
    }

    [Test]
    public void TestTapShaftButtonByCoordinates()
    {
        int x = 850;
        int y = 750;
        var pointer = new PointerInputDevice(PointerKind.Touch);
        var sequence = new ActionSequence(pointer, 0);
        sequence.AddAction(pointer.CreatePointerMove(CoordinateOrigin.Viewport, x, y, TimeSpan.Zero));
        sequence.AddAction(pointer.CreatePointerDown(0));
        sequence.AddAction(pointer.CreatePointerUp(0));
        _driver.PerformActions(new List<ActionSequence> { sequence });
    }

    [Test]
    public void TestTapBasicFlatnessButtonByCoordinates()
    {
        int x = 850;
        int y = 1050;
        var pointer = new PointerInputDevice(PointerKind.Touch);
        var sequence = new ActionSequence(pointer, 0);
        sequence.AddAction(pointer.CreatePointerMove(CoordinateOrigin.Viewport, x, y, TimeSpan.Zero));
        sequence.AddAction(pointer.CreatePointerDown(0));
        sequence.AddAction(pointer.CreatePointerUp(0));
        _driver.PerformActions(new List<ActionSequence> { sequence });
    }

    [Test]
    public void TestTapStraightnessButtonByCoordinates()
    {
        int x = 850;
        int y = 1350;
        var pointer = new PointerInputDevice(PointerKind.Touch);
        var sequence = new ActionSequence(pointer, 0);
        sequence.AddAction(pointer.CreatePointerMove(CoordinateOrigin.Viewport, x, y, TimeSpan.Zero));
        sequence.AddAction(pointer.CreatePointerDown(0));
        sequence.AddAction(pointer.CreatePointerUp(0));
        _driver.PerformActions(new List<ActionSequence> { sequence });
    }

    [Test]
    public void TestTapValuesButtonByCoordinates()
    {
        int x = 850;
        int y = 1650;
        var pointer = new PointerInputDevice(PointerKind.Touch);
        var sequence = new ActionSequence(pointer, 0);
        sequence.AddAction(pointer.CreatePointerMove(CoordinateOrigin.Viewport, x, y, TimeSpan.Zero));
        sequence.AddAction(pointer.CreatePointerDown(0));
        sequence.AddAction(pointer.CreatePointerUp(0));
        _driver.PerformActions(new List<ActionSequence> { sequence });
    }
}
