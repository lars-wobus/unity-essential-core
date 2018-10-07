namespace Essential.Core.Memory
{
    /// <summary>
    /// Allows to store a single internal state of an Originator.
    /// </summary>
    /// <typeparam name="TData">Type of data to be saved.</typeparam>
    public class Caretaker<TData>
    {
        /// <summary>
        /// Get saved internal state of an Originator.
        /// </summary>
        public TData Memento { get; }
    
        /// <summary>
        /// While creating a new instance, the passed internal state of an Originator will be saved.
        /// </summary>
        /// <param name="objectInstance">Current internal state of an Originator.</param>
        public Caretaker(TData objectInstance)
        {
            Memento = objectInstance;
        }
    }
}
