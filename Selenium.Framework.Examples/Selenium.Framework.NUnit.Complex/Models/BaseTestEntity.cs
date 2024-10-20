using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Framework.NUnit.Complex.Models;

public abstract class BaseTestEntity
{
    public char Run { get; set; }

    public string TestCaseId { get; set; } = string.Empty;

    public string TestCaseName { get; set; } = string.Empty;

    public ChromeDriver? Driver { get; set; }

    public override string ToString()
    {
        return $" {TestCaseId}_{TestCaseName}";
    }
}
