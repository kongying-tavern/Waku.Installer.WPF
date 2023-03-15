using System;
using System.Threading;

namespace WpfApp;

public static class EntryPoint
{
    private const string MutexId = $"Global\\{GlobalVars.AppGuid}";

    /// <summary>
    ///     WPF applications must run in a single-threaded apartment
    /// </summary>
    [STAThread]
    public static void Main()
    {
        using Mutex mutex = new(true, MutexId, out bool isSingleInstance);

        SingleInstanceManager(isSingleInstance);
    }

    private static void SingleInstanceManager(bool isSingleInstance)
    {
        if (isSingleInstance)
        {
            // Start the WPF application
            App app = new();
            app.Run();
        }
        else
        {
            Utils.SetInstanceAsForegroundWindowWithFlash(GlobalVars.MainWindowName);
        }
    }
}