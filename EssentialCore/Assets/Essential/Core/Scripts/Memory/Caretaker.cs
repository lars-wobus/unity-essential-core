namespace Essential.Core.Memory
{
    public class Caretaker<T>
    {
        public T Memento { get; }
    
        public Caretaker(T objectInstance)
        {
            Memento = objectInstance;
        }
    }
}
