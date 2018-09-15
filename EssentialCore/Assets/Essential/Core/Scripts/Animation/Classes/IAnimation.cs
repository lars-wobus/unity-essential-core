namespace Essential.Core.Animation.Classes
{
	public interface IAnimation
	{
		void HandleProgressChange(float progress);
		void HandleApplicationQuit();
	}
}
