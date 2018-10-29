namespace Essential.Core.Localization
{
    public interface ITextComponent
    {
        void SetText(string text);
        string Id { get; }
    }
}
