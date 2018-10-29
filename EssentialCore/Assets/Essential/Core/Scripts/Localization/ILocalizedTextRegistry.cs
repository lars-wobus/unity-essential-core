namespace Essential.Core.Localization
{
	public interface ILocalizedTextRegistry
	{
		bool Register(ITextComponent element);
		bool Unregister(ITextComponent element);
	}
}
