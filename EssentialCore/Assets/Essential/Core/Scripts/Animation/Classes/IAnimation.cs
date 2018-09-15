using UnityEngine;

namespace Essential.Core.Animation.Classes
{
	public interface IAnimation
	{
		void HandleApplicationStart();
		void HandleApplicationQuit();
		void HandleProgressChange(float progress);
	}
}
