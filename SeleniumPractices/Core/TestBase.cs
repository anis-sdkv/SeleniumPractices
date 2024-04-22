using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumPractices.Models;

namespace SeleniumPractices.Core;

[TestFixture]
public abstract class TestBase
{
    protected AppManager App = null!;

    [SetUp]
    public void SetUp()
    {
        App = AppManager.GetInstance();
    }
}