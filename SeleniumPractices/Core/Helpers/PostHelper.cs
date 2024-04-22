using OpenQA.Selenium;
using SeleniumPractices.Models;

namespace SeleniumPractices.Core.Helpers;

public class PostHelper : HelperBase
{
    public PostHelper(AppManager manager) : base(manager)
    {
    }

    public void OpenLastCreatedPostToEdit()
    {
        Driver.FindElement(By.LinkText("Ваши сообщения")).Click();
        Driver.FindElement(By.XPath("//p/a[4]")).Click();
        Driver.FindElement(By.CssSelector(".tablebg:nth-child(15) .gensmall:nth-child(2) > a:nth-child(1) > img"))
            .Click();
    }

    public PostModel GetCreatedPostData()
    {
        var text = Driver.FindElement(By.Name("message")).Text;
        var bbCode = Driver.FindElement(By.Name(PostModel.BbCode)).Selected;
        var attachSign = Driver.FindElement(By.Name(PostModel.AttachSign)).Selected;
        var smiles = Driver.FindElement(By.Name(PostModel.DisableSmiles)).Selected;
        var magicUrl = Driver.FindElement(By.Name(PostModel.DisableMagicUrl)).Selected;
        var notify = Driver.FindElement(By.Name(PostModel.Notify)).Selected;

        return new PostModel(text, bbCode, smiles, magicUrl, attachSign, notify);
    }

    public void CreateNewPost(PostModel post)
    {
        // Driver.FindElement(By.CssSelector("#pagecontent > table:nth-child(1) img")).Click();
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