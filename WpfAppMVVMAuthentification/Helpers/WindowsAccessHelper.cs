using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVMAuthentification.Helpers
{
   public  class WindowsAccessHelper
    {
        // faire appel à des bibliotheque windows --> qui existait depuis le version 32b de Windows
        // confie celà à une table particulère 
        // directives --> instruction donnée au comilateur pour lui dire de faire quelque chose
        [STAThread]
        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        public static extern bool LogonUser(string userName, string domainName,
            string password, int LogonType,
            int LogonProvider, ref IntPtr phToken);


        public static bool IsValidateCredentials (string userName,string password,string domain)
        {
            bool isValid = false;
            // utilise un code managé => pas de pointeur 
            IntPtr tokenHandler = IntPtr.Zero;

            isValid = LogonUser(userName, domain, password, 2, 0, ref tokenHandler);

            return isValid;

        }
    }
}
