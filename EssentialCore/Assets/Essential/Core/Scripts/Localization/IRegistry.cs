namespace Essential.Core.Localization
{
	public interface IRegistry
	{
		bool Register(ITextComponent element);
		bool Unregister(ITextComponent element);
	}
}
