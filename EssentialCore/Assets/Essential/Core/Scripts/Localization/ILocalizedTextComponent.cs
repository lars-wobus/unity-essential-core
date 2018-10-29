namespace Essential.Core.Localization
{
    public interface ILocalizedTextComponent
    {
        string Id { get; }
        void SetText(string text);
    }
}
