using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Framework.NUnit.Complex.Extensions;

public static class IWebDriverExtensions
{
    public static IWebElement? WaitToFindElementBy(this IWebDriver driver, By by, TimeSpan? timeout = null)
    {
        timeout ??= TimeSpan.FromSeconds(10);

		try
		{
			WebDriverWait wait = new(driver, timeout.Value);
			wait.IgnoreExceptionTypes();

			return wait.Until(d => d.FindElement(by));
		}
		catch
		{
			return null;
		}
    }
}
