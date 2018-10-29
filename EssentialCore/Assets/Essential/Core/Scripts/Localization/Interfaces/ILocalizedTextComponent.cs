namespace Essential.Core.Localization.Interfaces
{
    public interface ILocalizedTextComponent
    {
        string Id { get; }
        void SetText(string text);
    }
}
