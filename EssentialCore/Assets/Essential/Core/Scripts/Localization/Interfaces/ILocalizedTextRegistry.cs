namespace Essential.Core.Localization.Interfaces
{
	public interface ILocalizedTextRegistry
	{
		bool Register(ILocalizedTextComponent element);
		bool Unregister(ILocalizedTextComponent element);
	}
}
