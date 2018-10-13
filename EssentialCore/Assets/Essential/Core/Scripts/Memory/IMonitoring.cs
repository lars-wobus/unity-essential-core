namespace Essential.Core.Memory
{
    public interface IMonitoring
    {
        void OnStateSaved(int index);
        void OnStateRestored(int index);
        void OnStateRemoved(int index);
        void OnRestorationFailed(int index);
        void OnRemovingFailed(int index);
    }
}
