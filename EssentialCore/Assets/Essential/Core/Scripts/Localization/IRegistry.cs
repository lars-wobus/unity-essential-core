using UnityEngine;

namespace Essential.Core.Localization
{
	public interface IRegistry
	{
		bool Register(IRegisterable element);
		bool Unregister(IRegisterable element);
	}
}
