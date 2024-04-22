using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumPractices.Core;

public abstract class HelperBase
{
    protected IWebDriver Driver;
    protected AppManager Manager;

    protected HelperBase(AppManager manager)
    {
        Manager = manager;
        Driver = manager.Driver;
    }
}