using System.Reflection;
using System.Runtime.InteropServices;

namespace PInvokeSystem;
class Program
{
    static void Main(string[] args)
    {
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
        Invoker.TraverseDirectoriesAndPrintFilenames("..");
        Console.WriteLine("Finished");
    }

    private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName == "libc")
        {
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return NativeLibrary.Load("libc.so.6", assembly, searchPath);
            }
            else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return NativeLibrary.Load("libSystem.dylib", assembly, searchPath);
            }
        }
        
        return IntPtr.Zero;
    }
}


