using System;
using System.IO;

using Windows.Win32;
using Windows.Win32.System.Com;
using Windows.Win32.UI.Shell;

namespace WpfApp.Utils;

public static class ZipFile
{
    public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName)
    {
        string fileFullPath = Path.GetFullPath(sourceArchiveFileName);
        string targetFullPath = Path.GetFullPath(destinationDirectoryName);

        if (!System.IO.Directory.Exists(targetFullPath))
        {
            throw new ArgumentException("Can not find target directory.");
        }

        if (!Path.GetFileName(fileFullPath).EndsWith("zip"))
        {
            throw new ArgumentException("Can not find zip file.");
        }

        PInvoke.CoCreateInstance(
            typeof(Shell).GUID,
            null,
            CLSCTX.CLSCTX_INPROC_SERVER,
            out IShellDispatch shell).ThrowOnFailure();

        shell.NameSpace(targetFullPath).CopyHere(shell.NameSpace(fileFullPath).Items(), 16);
    }
}