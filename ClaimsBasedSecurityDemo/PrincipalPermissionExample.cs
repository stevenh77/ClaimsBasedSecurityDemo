using System;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;

namespace ClaimsBasedSecurityDemo
{
    class PrincipalPermissionExample
    {
        public void Execute()
        {
            PrintHeader();

            var principal = new GenericPrincipal(
                new GenericIdentity("Steven"), 
                new [] {"Sales", "Marketing"});

            Thread.CurrentPrincipal = principal;
            var currentPrincipal = Thread.CurrentPrincipal;

            if (currentPrincipal.IsInRole("Development"))
            {
                // do this
            }
            else
            {
                // access denied
            }

            try
            {
                new PrincipalPermission(null, "Development").Demand();
                Console.WriteLine("You are a developer");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }

            try
            {
                DoDeveloperWork();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Development")]
        private void DoDeveloperWork()
        {
            Console.WriteLine("You are a developer");
        }

        private void PrintHeader()
        {
            Console.WriteLine("Principal Permission Examples");
            Console.WriteLine("_____________________________");
            Console.WriteLine();
        }
    }
}
