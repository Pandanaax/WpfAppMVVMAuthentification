using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVMAuthentification.Helper
{
    public class WindowsAccessHelper
    {
        // faire appel à des bibliotheques windows --> qui existait depuis
        // la version 32b de Windows
        // confie celà à une table particulière 
        [STAThread]
        [System.Runtime.InteropServices.DllImport("advapi32.dll")]

        public static extern bool LogonUser(string userName, string domainName,
            string password, int LogonType,
            int LogonProvider, ref IntPtr phToken);

        public static bool IsValidateCredentials (string userName, string password, string domain)
        {
            bool isValid = false;
            // utilise un code managé => pas de pointeur
            IntPtr tokenHandler = IntPtr.Zero;

            isValid = LogonUser(userName, domain, password, 2, 0, ref tokenHandler);


            return isValid;
        }
    }
}
