using SeleniumPractices.Core;

namespace SeleniumPractices.Tests;

[TestFixture]
public class AuthTest : TestBase
{
    [Test]
    public void Test()
    {
        App.Navigation.OpenHomePage();
        App.Navigation.OpenLoginPage();
        App.Auth.Login(App.Auth.TestAccount);
    }
}