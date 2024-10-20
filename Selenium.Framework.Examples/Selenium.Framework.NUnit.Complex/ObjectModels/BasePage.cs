using OpenQA.Selenium.Chrome;
using Selenium.Framework.NUnit.Complex.Models;
using Selenium.Framework.NUnit.Complex.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Framework.NUnit.Complex.ObjectModels;

public class BasePage
{
    protected ChromeDriver Driver => BaseTestSetup.Entity.Driver
        ?? throw new ArgumentNullException("The Driver wasn't instantiated correctly!");

    protected BaseTestEntity Entity => BaseTestSetup.Entity;

    public string Url => Driver.Url;

    public void GoTo(string url) 
    {
        Driver.Navigate().GoToUrl(url);
    }
}
