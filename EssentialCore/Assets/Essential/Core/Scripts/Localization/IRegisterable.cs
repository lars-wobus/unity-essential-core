namespace Essential.Core.Localization
{
	public interface IRegisterable
	{
		void Register(IRegistry registry);
		void Unregister(IRegistry registry);
	}
}
