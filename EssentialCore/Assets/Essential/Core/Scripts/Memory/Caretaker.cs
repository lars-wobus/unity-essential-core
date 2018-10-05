namespace Essential.Core.Memory
{
    /// <summary>
    /// Allows to store a single internal state of an Originator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Caretaker<T>
    {
        /// <summary>
        /// Get saved internal state of an Originator.
        /// </summary>
        public T Memento { get; }
    
        /// <summary>
        /// While creating a new instance, the passed internal state of an Originator will be saved.
        /// </summary>
        /// <param name="objectInstance">Current internal state of an Originator.</param>
        public Caretaker(T objectInstance)
        {
            Memento = objectInstance;
        }
    }
}
