namespace Essential.Core.Animation
{
    public class ObserverState<T> // TODO AnimationProgress for example
    {
        public T Value { get; set; }

        public ObserverState(T value)
        {
            Value = value;
        }
    }
}