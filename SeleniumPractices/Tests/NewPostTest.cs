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

        var expectedModel = new PostModel("Проверка связи", NotifyEnabled: true);

        App.Navigation.OpenCreatePostPage();
        App.Post.CreateNewPost(expectedModel);

        // Assert
        App.Post.OpenLastCreatedPostToEdit();
        var actualModel = App.Post.GetCreatedPostData();
        Assert.That(actualModel, Is.EqualTo(expectedModel));
    }
}