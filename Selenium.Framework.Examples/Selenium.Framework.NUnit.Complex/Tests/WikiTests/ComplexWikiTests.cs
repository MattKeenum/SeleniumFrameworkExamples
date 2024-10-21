using Selenium.Framework.NUnit.Complex.DataProviders;
using Selenium.Framework.NUnit.Complex.Models;
using Selenium.Framework.NUnit.Complex.ObjectModels;

namespace Selenium.Framework.NUnit.Complex.Tests.GoogleTests;

public class ComplexWikiTests : WikiTestSetup
{
    [SetUp]
    public void WikiSetup()
    {
        new WikiSearchPage().GoTo();
    }

    [Test]
    [TestCaseSource(typeof(TestCaseProvider<WikiTestEntity>), nameof(TestCaseProvider<WikiTestEntity>.GetData), new object[] { "WikiSearchTests.csv" })]
    public void SearchTests(WikiTestEntity entity)
    {
        WikiSearchPage page = new();
        entity.SearchTerm = "Selenium";

        page.Search(entity.SearchTerm);

        Assert.That(page.GetArticleTitle, Does.Contain(entity.SearchTerm), $"Failed to search for {entity.SearchTerm}");
    }
}