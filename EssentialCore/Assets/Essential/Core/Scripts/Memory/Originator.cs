using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Essential.Core.Memory
{
	/// <summary>
	/// Allows to save and restore states.
	/// </summary>
	/// <typeparam name="TData">Type of data to be saved.</typeparam>
	public class Originator<TData>
	{
		/// <summary>
		/// Current internal state.
		/// </summary>
		private IRecoverable<TData> TargetScript { get; }
		// place for additional data that is not part of the state being saved in memento, e.g. load/save counter, etc.

		public Originator(IRecoverable<TData> customBehaviour)
		{
			TargetScript = customBehaviour;
		}

		/// <summary>
		/// Create memento that stores the originator's current internal state.
		/// </summary>
		/// <returns>Copy of its own internal state.</returns>
		public TData SaveToMemento()
		{
			// ReSharper disable once HeapView.BoxingAllocation
			return (TargetScript == null || TargetScript.Data == null) ? default(TData) : _serialize(TargetScript.Data);
		}

		/// <summary>
		/// Restore internal state from passed memento.
		/// </summary>
		/// <param name="storedInstance">Any internal state from the past.</param>
		/// <returns>Internal state after adopting or rejecting the input.</returns>
		public TData RestoreFromMomento(TData storedInstance)
		{
			// ReSharper disable once HeapView.BoxingAllocation
			if (storedInstance == null)
			{
				return TargetScript.Data;
			}
			
			return TargetScript.Data = storedInstance;
		}

		/// <summary>
		/// Create copy of your current internal state. 
		/// </summary>
		private readonly Func<TData, TData> _serialize = objectInstance =>
		{
			var memoryStream = new MemoryStream();
			var binaryFormatter = new BinaryFormatter();

			// ReSharper disable once HeapView.BoxingAllocation
			binaryFormatter.Serialize(memoryStream, objectInstance);
			memoryStream.Seek(0, SeekOrigin.Begin);

			var objectCopy = (TData) binaryFormatter.Deserialize(memoryStream);
			memoryStream.Close();
			return objectCopy;
		};
	}
}
