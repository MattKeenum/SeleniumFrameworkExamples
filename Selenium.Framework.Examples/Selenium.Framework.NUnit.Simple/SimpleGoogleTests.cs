using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium.Framework.NUnit.Simple;

public class SimpleGoogleTests
{
    private ChromeDriver? Driver { get; set; }

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());

        ChromeOptions options = new();
        options.AddArgument("--start-maximized");

        Driver = new ChromeDriver(options);
    }

    [TearDown]
    public void TearDown()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }

    [Test]
    public void NavigateToHomePage()
    {
        Driver!.Navigate().GoToUrl("https://www.google.com");
        Assert.That(Driver.Url, Does.Contain("google"), "Failed to navigate to Google");
    }
}