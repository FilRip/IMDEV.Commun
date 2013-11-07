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

        public static bool setRights(string folder, string user, bool removeRights)
        {
            return setRights(folder, user, removeRights, false);
        }
        public static bool setRights(string folder, string user, bool removeRights, bool write)
        {
            System.Security.AccessControl.DirectorySecurity a;

            try
            {
                if (System.IO.Directory.Exists(folder))
                {
                    a = System.IO.Directory.GetAccessControl(folder);
                    a.RemoveAccessRuleAll(new System.Security.AccessControl.FileSystemAccessRule(user, System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.AccessControlType.Allow));
                    if (removeRights) return true;
                    if (write)
                        a.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule(user, System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.InheritanceFlags.ContainerInherit | System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, System.Security.AccessControl.AccessControlType.Allow));
                    else
                        a.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule(user, System.Security.AccessControl.FileSystemRights.ReadAndExecute | System.Security.AccessControl.FileSystemRights.ListDirectory | System.Security.AccessControl.FileSystemRights.Read, System.Security.AccessControl.InheritanceFlags.ContainerInherit | System.Security.AccessControl.InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.None, System.Security.AccessControl.AccessControlType.Allow));
                    System.IO.Directory.SetAccessControl(folder,a);
                    return true;
                }
            }
            catch { }
            return false;
        }
}
}
