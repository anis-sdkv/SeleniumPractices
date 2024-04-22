using OpenQA.Selenium;
using SeleniumPractices.Models;

namespace SeleniumPractices.Core;

public class AuthHelper : HelperBase
{
    public readonly AccountModel TestAccount = new AccountModel("SeleniumTest123", "Seltest123");

    public bool IsAuthorized => Driver.FindElement(By.LinkText("Вход")) == null;
    
    public AuthHelper(ApplicationManager manager) : base(manager)
    {
    }

    public void Login(AccountModel account)
    {
        Driver.FindElement(By.Name("username")).SendKeys(account.Login);
        Driver.FindElement(By.Name("password")).SendKeys(account.Password);
        Driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
    }
}