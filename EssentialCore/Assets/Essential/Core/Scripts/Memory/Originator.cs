using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Essential.Core.Memory
{
	public class Originator<T> where T : class 
	{
		public T CurrentState { get; set; }

		public T SaveToMemento()
		{
			// ReSharper disable once HeapView.BoxingAllocation
			return CurrentState == null ? CurrentState : _serialize(CurrentState);
		}

		public /*T*/void RestoreFromMomento(T storedInstance)
		{
			if (storedInstance == null)
			{
				return;
			}
			CurrentState = storedInstance;
			//return CurrentState;
		}

		private readonly Func<T, T> _serialize = objectInstance =>
		{
			var memoryStream = new MemoryStream();
			var binaryFormatter = new BinaryFormatter();

			// ReSharper disable once HeapView.BoxingAllocation
			binaryFormatter.Serialize(memoryStream, objectInstance);
			memoryStream.Seek(0, SeekOrigin.Begin);

			var objectCopy = (T) binaryFormatter.Deserialize(memoryStream);
			memoryStream.Close();
			return objectCopy;
		};
	}
}
