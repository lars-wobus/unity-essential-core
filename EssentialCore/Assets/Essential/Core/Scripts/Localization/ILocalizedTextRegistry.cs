namespace Essential.Core.Localization
{
	public interface ILocalizedTextRegistry
	{
		bool Register(ILocalizedTextComponent element);
		bool Unregister(ILocalizedTextComponent element);
	}
}
