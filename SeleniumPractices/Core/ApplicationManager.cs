using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumPractices.Core;

public class ApplicationManager
{
    public IWebDriver Driver { get; init; }
    public NavigationHelper Navigation { get; init; }
    public AuthHelper Auth { get; init; }
    public PostHelper Post { get; init; }

    private StringBuilder _verificationErrors = new StringBuilder();
    private readonly string _baseUrl = "https://forum.supermamki.ru";

    public ApplicationManager()
    {
        Driver = new FirefoxDriver();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Navigation = new NavigationHelper(this, _baseUrl);
        Auth = new AuthHelper(this);
        Post = new PostHelper(this);
    }

    public void Stop()
    {
        Driver.Quit();
    }
}