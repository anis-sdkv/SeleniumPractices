using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumPractices.Models;

namespace SeleniumPractices;

[TestFixture]
public class TestBase
{
    private IWebDriver _driver;
    protected readonly AccountModel TestAccount = new AccountModel("SeleniumTest123", "Seltest123");

    [SetUp]
    public void SetUp()
    {
        _driver = new FirefoxDriver();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [TearDown]
    protected void TearDown()
    {
        _driver.Quit();
    }


    protected void OpenHomePage()
    {
        _driver.Navigate().GoToUrl("https://forum.supermamki.ru/index.php");
    }

    protected void Login(AccountModel account)
    {
        _driver.FindElement(By.LinkText("Вход")).Click();
        _driver.FindElement(By.Name("username")).SendKeys(account.Login);
        _driver.FindElement(By.Name("password")).SendKeys(account.Password);
        _driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
    }

    protected bool IsAuthorized => _driver.FindElement(By.LinkText("Вход")) == null;

    protected void CreateNewPost(PostModel post)
    {
        _driver.FindElement(By.LinkText("Активные темы")).Click();
        _driver.FindElement(By.LinkText("Болталка")).Click();

        _driver.FindElement(By.CssSelector("#pagecontent > table:nth-child(1) img")).Click();
        _driver.FindElement(By.Name("message")).Click();
        _driver.FindElement(By.Name("message")).SendKeys(post.Message);

        _driver.FindElement(By.CssSelector("tr:nth-child(2) a:nth-child(5) > img")).Click();
        SetPostButtons(post);

        _driver.FindElement(By.Name("post")).Click();
    }

    private void SetPostButtons(PostModel post)
    {
        var buttons = new[]
        {
            (PostModel.BbCode, post.BbCodeEnabled),
            (PostModel.DisableSmiles, post.SmilesEnabled),
            (PostModel.DisableMagicUrl, post.MagicUrlEnabled),
            (PostModel.AttachSign, post.AttachSignEnabled),
            (PostModel.Notify, post.NotifyEnabled)
        };

        foreach (var (button, value) in buttons) SetRadioButton(button, value);
    }

    private void SetRadioButton(string name, bool expectedValue)
    {
        var button = _driver.FindElement(By.Name(name));
        if (button.Selected != expectedValue) button.Click();
    }
}