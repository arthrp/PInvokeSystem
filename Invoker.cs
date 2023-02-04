using System.Runtime.InteropServices;

namespace PInvokeSystem;

public class Invoker
{
    private delegate int DirCallback(string fName, StatClass stat, int typeFlag);
    
    [DllImport("libc")]
    private static extern int ftw(string dirpath, DirCallback cl, int descriptors);
    
    private static int PrintEntryName(string fName, StatClass stat, int typeFlag)
    {
        Console.WriteLine($"{fName}");
        return 0;
    }
    
    public static void TraverseDirectoriesAndPrintFilenames(string dirPath)
    {
        ftw(dirPath, PrintEntryName, 10);
    }
}

[StructLayout(LayoutKind.Sequential)]
public class StatClass
{
    public uint DeviceID;
    public uint InodeNumber;
    public uint Mode;
    public uint HardLinks;
    public uint UserID;
    public uint GroupID;
    public uint SpecialDeviceID;
    public ulong Size;
    public ulong BlockSize;
    public uint Blocks;
    public long TimeLastAccess;
    public long TimeLastModification;
    public long TimeLastStatusChange;
}