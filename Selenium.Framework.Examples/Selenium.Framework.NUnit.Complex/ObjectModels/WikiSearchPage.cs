using OpenQA.Selenium;
using Selenium.Framework.NUnit.Complex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Framework.NUnit.Complex.ObjectModels;

public class WikiSearchPage : BasePage
{
    private IWebElement? SearchBar => Driver.WaitToFindElementBy(By.Id("searchInput"));

    private IWebElement? SearchButton => Driver.WaitToFindElementBy(By.CssSelector("button[type='submit']"));

    private IWebElement? Title => Driver.WaitToFindElementBy(By.CssSelector(".mw-page-title-main"));

    public string GetArticleTitle => Title?.Text ?? "Title element not found!";

    public void GoTo() => GoTo("https://www.wikipedia.org/");

    public void Search(string searchText)
    {
        SearchBar?.SendKeys(searchText);
        SearchButton?.Click();
    }
}
