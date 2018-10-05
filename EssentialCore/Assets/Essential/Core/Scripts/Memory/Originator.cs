using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Essential.Core.Memory
{
	/// <summary>
	/// Allows to save and restore states.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Originator<T> where T : class 
	{
		/// <summary>
		/// Current internal state.
		/// </summary>
		public T CurrentState { get; set; }
		// place for additional data that is not part of the state being saved in memento, e.g. load/save counter, etc.

		/// <summary>
		/// Create memento that stores the originator's current internal state.
		/// </summary>
		/// <returns>Copy of its own internal state.</returns>
		public T SaveToMemento()
		{
			// ReSharper disable once HeapView.BoxingAllocation
			return CurrentState == null ? CurrentState : _serialize(CurrentState);
		}

		/// <summary>
		/// Restore internal state from passed memento.
		/// </summary>
		/// <param name="storedInstance">Any internal state from the past.</param>
		/// <returns>Internal state after adopting or rejecting the input.</returns>
		public T RestoreFromMomento(T storedInstance)
		{
			if (storedInstance == null)
			{
				return CurrentState;
			}
			CurrentState = storedInstance;
			return CurrentState;
		}

		/// <summary>
		/// Create copy of your current internal state. 
		/// </summary>
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
