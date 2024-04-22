using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumPractices.Core;

public abstract class HelperBase
{
    protected IWebDriver Driver;
    protected ApplicationManager Manager;

    protected HelperBase(ApplicationManager manager)
    {
        Manager = manager;
        Driver = manager.Driver;
    }
}