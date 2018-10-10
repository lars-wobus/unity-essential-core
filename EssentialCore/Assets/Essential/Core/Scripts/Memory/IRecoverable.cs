namespace Essential.Core.Memory
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TData">Type of data to own.</typeparam>
    public interface IRecoverable<TData>
    {
        TData Data { get; set; }
    }
}
