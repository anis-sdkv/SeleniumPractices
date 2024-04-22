using SeleniumPractices.Core;
using SeleniumPractices.Models;

namespace SeleniumPractices.Tests;

[TestFixture]
public class NewPostTest : TestBase
{
    [Test]
    public void Test()
    {
        App.Navigation.OpenHomePage();
        if (!App.Auth.IsAuthorized)
        {
            App.Navigation.OpenLoginPage();
            App.Auth.Login(App.Auth.TestAccount);
        }

        App.Navigation.OpenCreatePostPage();
        App.Post.CreateNewPost(new PostModel("Проверка связи :)", NotifyEnabled: true));
    }
}