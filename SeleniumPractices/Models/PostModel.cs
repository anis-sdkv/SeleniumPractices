namespace SeleniumPractices.Models;

public record PostModel(
    string Message,
    bool BbCodeEnabled = false,
    bool SmilesEnabled = false,
    bool MagicUrlEnabled = false,
    bool AttachSignEnabled = false,
    bool NotifyEnabled = false
)
{
    public const string BbCode = "disable_bbcode";
    public const string DisableSmiles = "disable_smilies";
    public const string DisableMagicUrl = "disable_magic_url";
    public const string AttachSign = "attach_sig";
    public const string Notify = "notify";
}