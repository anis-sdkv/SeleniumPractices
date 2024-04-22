using SeleniumPractices.Models;

namespace SeleniumPractices;

[TestFixture]
public class NewPostTest : TestBase
{
    [Test]
    public void Test()
    {
        OpenHomePage();
        if (!IsAuthorized) Login(TestAccount);
        CreateNewPost(new PostModel("Проверка связи :)", NotifyEnabled: true));
    }
}