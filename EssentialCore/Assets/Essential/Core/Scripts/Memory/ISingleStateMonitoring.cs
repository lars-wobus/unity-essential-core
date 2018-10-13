namespace Essential.Core.Memory
{
	public interface ISingleStateMonitoring
	{
		void OnStateSaved();
		void OnStateRestored();
	}
}
