using OpenQA.Selenium;
using SeleniumPractices.Models;

namespace SeleniumPractices.Core;

public class PostHelper : HelperBase
{
    public PostHelper(ApplicationManager manager) : base(manager)
    {
    }

    public void CreateNewPost(PostModel post)
    {
        Driver.FindElement(By.CssSelector("#pagecontent > table:nth-child(1) img")).Click();
        Driver.FindElement(By.Name("message")).Click();
        Driver.FindElement(By.Name("message")).SendKeys(post.Message);

        Driver.FindElement(By.CssSelector("tr:nth-child(2) a:nth-child(5) > img")).Click();
        SetPostButtons(post);

        Driver.FindElement(By.Name("post")).Click();
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
        var button = Driver.FindElement(By.Name(name));
        if (button.Selected != expectedValue) button.Click();
    }
}