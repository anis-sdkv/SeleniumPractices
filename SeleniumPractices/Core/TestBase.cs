using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumPractices.Models;

namespace SeleniumPractices.Core;

[TestFixture]
public abstract class TestBase
{
    protected ApplicationManager App = null!;

    [SetUp]
    public void SetUp()
    {
        App = new ApplicationManager();
    }

    [TearDown]
    protected void TearDown()
    {
        App.Stop(); 
    }
}