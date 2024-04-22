using NUnit.Framework;
using SeleniumPractices.Models;

namespace SeleniumPractices;

[TestFixture]
public class AuthTest : TestBase
{
    [Test]
    public void Test()
    {
        OpenHomePage();
        Login(TestAccount);
    }
}