namespace Essential.Core.Localization
{
    public interface ITextComponent
    {
        string Id { get; }
        void SetText(string text);
    }
}
