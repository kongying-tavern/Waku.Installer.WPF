using Windows.Win32;
using Windows.Win32.Foundation;

using static Windows.Win32.UI.WindowsAndMessaging.SHOW_WINDOW_CMD;

namespace WpfApp.Utils;

public static class Interop
{
    public static void SetInstanceAsForegroundWindow(string instanceWindowName)
    {
        HWND instanceHandle = PInvoke.FindWindow(null, instanceWindowName);
        PInvoke.ShowWindow(instanceHandle, SW_SHOWNORMAL);
        PInvoke.SetForegroundWindow(instanceHandle);
    }

    public static void SetInstanceAsForegroundWindowWithFlash(string instanceWindowName)
    {
        HWND instanceHandle = PInvoke.FindWindow(null, instanceWindowName);
        SetInstanceAsForegroundWindow(instanceWindowName);
        PInvoke.FlashWindow(instanceHandle, true);
    }
}