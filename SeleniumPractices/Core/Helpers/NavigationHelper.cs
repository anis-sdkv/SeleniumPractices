using OpenQA.Selenium;

namespace SeleniumPractices.Core.Helpers;

public class NavigationHelper : HelperBase
{
    private readonly string baseUrl;

    public NavigationHelper(AppManager manager, string baseUrl) : base(manager)
    {
        this.baseUrl = baseUrl;
    }

    public void OpenHomePage()
    {
        Driver.Navigate().GoToUrl($"{baseUrl}/index.php");
    }

    public void OpenLoginPage()
    {
        Driver.FindElement(By.LinkText("Вход")).Click();
    }

    public void OpenCreatePostPage(string topic = "Болталка")
    {
        Driver.FindElement(By.LinkText("Активные темы")).Click();
        Driver.FindElement(By.LinkText(topic)).Click();
    }
}