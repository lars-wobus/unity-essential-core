namespace Essential.Core.Animation.Classes
{
	public interface IAnimator
	{
		void HandleProgressChange(float progress);
		void HandleApplicationQuit();
	}
}
