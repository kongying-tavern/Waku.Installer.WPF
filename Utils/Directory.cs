using System;
using System.IO;

namespace WpfApp.Utils;

public static class Directory
{
    public static DirectoryInfo CreateTempSubdirectory(string? prefix = null)
    {
        EnsureNoDirectorySeparators(prefix);
        return new DirectoryInfo(CreateTempSubdirectoryCore(prefix));
    }

    private static string CreateTempSubdirectoryCore(string? prefix = null)
    {
        var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        if (prefix is not null) path = Path.Combine(prefix, path);
        System.IO.Directory.CreateDirectory(path);
        return path;
    }

    private static void EnsureNoDirectorySeparators(string? value)
    {
        if (value?.IndexOfAny(new char[Path.DirectorySeparatorChar]) >= 0)
            throw new ArgumentException("UnsupportedTempDirName", value);
    }
}