using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using Selenium.Framework.NUnit.Complex.Models;
using OpenQA.Selenium;

namespace Selenium.Framework.NUnit.Complex.Tests;

/*
 *  This class is used and is executed based on namespace. 
 *  Any test classes that are childeren of this namespace will be part of this SetUpFixture.
 *  Separate SetUpFixtures can be used in different namespaces for different purposes.
 */
[SetUpFixture]
public class SetUpFixture
{
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        // Logic here to run a single time, regardless of the number of tests selected to run
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        // Logic here to run a single time, regardless of the number of tests selected to run
    }
}

public class BaseTestSetup
{
    public static BaseTestEntity Entity => TestContext.CurrentContext.Test.Arguments.FirstOrDefault() as BaseTestEntity
        ?? throw new ArgumentNullException($"Unable to cast the first argument of the test as a {nameof(BaseTestEntity)}");

    [SetUp]
    public void SetUp()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());

        ChromeOptions options = new();
        options.AddArgument("--start-maximized");

        Entity.Driver = new ChromeDriver(options);
    }

    [TearDown]
    public void TearDown()
    {
        Entity.Driver?.Quit();
        Entity.Driver?.Dispose();
    }
}
