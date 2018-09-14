namespace Essential.Core.Animation
{
    /// <summary>
    /// Allows to sync animations.
    /// </summary>
    /// <remarks>
    /// Any child class should not implement Update() and FixedUpdate().
    /// </remarks>
    public interface IAnimation
    {
        /// <summary>
        /// Set animation progress. 
        /// </summary>
        /// <param name="progress">Animation progress must be clamped in child class.</param>
        void SetProgress(double progress);
    }
}