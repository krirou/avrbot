using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Utility.DriverManagement
{
    //class utiliser pour le pilote de communication 
    public class DriverManagement
    {

        #region Constantes pour le driver

        public const int INVALID_HANDLE_VALUE = -1;


        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint GENERIC_EXECUTE = 0x20000000;
        public const uint GENERIC_ALL = 0x10000000;

        public const uint FILE_SHARE_READ = 0x00000001;
        public const uint FILE_SHARE_WRITE = 0x00000002;
        public const uint FILE_SHARE_DELETE = 0x00000004;

        public const uint CREATE_NEW = 1;
        public const uint CREATE_ALWAYS = 2;
        public const uint OPEN_EXISTING = 3;
        public const uint OPEN_ALWAYS = 4;
        public const uint TRUNCATE_EXISTING = 5;

        public const uint FILE_DEVICE_UNKNOWN = 0x00000022;

        public const uint METHOD_BUFFERED = 0;
        public const uint METHOD_IN_DIRECT = 1;
        public const uint METHOD_OUT_DIRECT = 2;
        public const uint METHOD_NEITHER = 3;

        public const uint FILE_ANY_ACCESS = 0;
        public const uint FILE_SPECIAL_ACCESS = FILE_ANY_ACCESS;
        public const uint FILE_READ_ACCESS = 0x0001;     // file & pipe
        public const uint FILE_WRITE_ACCESS = 0x0002;   // file & pipe
        #endregion


        #region Déclaration des fonctions pour le driver

        // Déclaration de CreateFile
        [DllImport("coredll.dll")]
        public static extern IntPtr CreateFile(
            string lpFileName, uint dwDesiredAccess, uint dwShareMode,
            IntPtr lpSecurityAttributes, uint dwCreationDisposition,
            int dwFlagsAndAttributes, IntPtr hTemplateFile);

        // Déclaration et définition de CTl_CODE
        public static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
        {
            return ((DeviceType << 16) | (Access << 14) | (Function << 2) | Method);
        }

        // Déclaration de DeviceIoControl
        [DllImport("coredll.dll")]
        public static extern bool DeviceIoControl(
            IntPtr hDevice, uint dwIoControlCode, IntPtr lpInBuffer, int nInBufferSize,
            IntPtr lpOutBuffer, int nOutBufferSize, ref int lpBytesReturned, IntPtr lpOverlapped);


        // Déclaration de CloseHandle
        [DllImport("coredll.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        #endregion



    }

}
