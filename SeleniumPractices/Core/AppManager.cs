using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumPractices.Core.Helpers;

namespace SeleniumPractices.Core;

public class AppManager
{
    private static readonly ThreadLocal<AppManager> App = new();
    public static AppManager GetInstance()
    {
        if (!App.IsValueCreated)
        {
            var newInstance = new AppManager();
            newInstance.Navigation.OpenHomePage();
            App.Value = newInstance;
        }
        return  App.Value!;
    }

    public IWebDriver Driver { get; init; }
    public NavigationHelper Navigation { get; init; }
    public AuthHelper Auth { get; init; }
    public PostHelper Post { get; init; }

    private StringBuilder _verificationErrors = new StringBuilder();
    private readonly string _baseUrl = "https://forum.supermamki.ru";

    private AppManager()
    {
        Driver = new FirefoxDriver();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Navigation = new NavigationHelper(this, _baseUrl);
        Auth = new AuthHelper(this);
        Post = new PostHelper(this);
    }

    ~AppManager()
    {
        try
        {
            Driver.Quit();
        }
        catch (Exception)
        { 
            //ignore
        }
    }
}