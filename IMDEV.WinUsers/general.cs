using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace IMDEV.WinUsers
{
    public class general
    {
        public static bool IsUserAdministrator(string username)
        {
            try
            {
                //get the currently logged in user
                WindowsIdentity user = new WindowsIdentity(username);
                WindowsPrincipal principal = new WindowsPrincipal(user);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch { }
            return false;
        }

        public static bool IsUserAdministrator()
        {
            return IsUserAdministrator(Environment.UserName);
        }
    }
}
