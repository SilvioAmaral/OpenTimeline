namespace OpenTimeline.Core.Config
{
    /// <summary>
    /// The Bootstrapper looks for all types implementing
    /// this interface and initializes them automatically.
    /// </summary>
    public interface IStartupTask
    {
        void Execute();
    }
}