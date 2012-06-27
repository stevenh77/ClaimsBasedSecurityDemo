using System;
using System.Security.Principal;

namespace ClaimsBasedSecurityDemo
{
    class WindowsIdentityExample
    {
        public void Execute()
        {
            PrintHeader();

            var id = WindowsIdentity.GetCurrent();
            Console.WriteLine("Identity Id: " + id.Name);

            var account = new NTAccount(id.Name);
            var sid = account.Translate(typeof(SecurityIdentifier));
            Console.WriteLine("SecurityIdentifier (sid): " + sid.Value);

            foreach (var group in id.Groups.Translate(typeof(NTAccount)))
                Console.WriteLine("InGroup: " + group);

            var principal = new WindowsPrincipal(id);
            var localAdmins = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
            Console.WriteLine("IsInRole(localAdmin): " + principal.IsInRole(localAdmins));


            var domainAdmins = new SecurityIdentifier(WellKnownSidType.AccountDomainAdminsSid, id.User.AccountDomainSid);
            Console.WriteLine("IsInRole(domainAdmin): " + principal.IsInRole(domainAdmins));
            Console.WriteLine();

            // be aware for desktop/local accounts User Account Control (UAC from Vista) strips user of admin rights, 
            // unless the process was run elevated "as Admin".
        }

        private void PrintHeader()
        {
            Console.WriteLine("Windows Identity Examples");
            Console.WriteLine("_________________________");
            Console.WriteLine();
        }
    }
}
