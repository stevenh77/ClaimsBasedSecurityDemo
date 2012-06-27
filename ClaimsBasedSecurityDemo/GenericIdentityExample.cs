using System;
using System.Security.Principal;
using System.Threading;

namespace ClaimsBasedSecurityDemo
{
    class GenericIdentityExample
    {
        public void Execute() 
        {
            PrintHeader();

            var identity = new GenericIdentity("Steven");
            var roles = new string[] { "Sales", "Marketing" };
            var principal = new GenericPrincipal(identity, roles);

            Thread.CurrentPrincipal = principal;

            var currentPrincipal = Thread.CurrentPrincipal;

            Console.WriteLine("Identity Name: " + currentPrincipal.Identity.Name);
            Console.WriteLine("IsInRole('Sales'): " + currentPrincipal.IsInRole("Sales"));
            Console.WriteLine();
        }

        private void PrintHeader()
        {
            Console.WriteLine("Generic Identity Examples");
            Console.WriteLine("_________________________");
            Console.WriteLine();
        }
    }
}
