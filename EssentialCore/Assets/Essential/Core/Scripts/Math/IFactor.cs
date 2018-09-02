namespace _Scripts.Math
{
    public interface IFactor<T>
    {
        T Evaluate(T value, float time);
    }
}