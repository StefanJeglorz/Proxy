using System.Runtime.CompilerServices;

namespace Proxy.Examples
{
    internal class TryCatchProxy : ITryCatchProxy
    {
        public void Try(Action action, Action<Exception>? OnExceptionOccured = null, [CallerFilePath] string? path = null, [CallerMemberName] string? caller = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:HH.mm:ss}] [Error] [{path} {caller}] - {ex.Message}");
                OnExceptionOccured?.Invoke(ex);
            }
        }
    }

    internal interface ITryCatchProxy
    {
        public void Try(Action action, Action<Exception>? OnExceptionOccured = null, [CallerFilePath] string? path = null, [CallerMemberName] string? caller = null);
    }
}
