using System;
using System.IdentityModel.Services;
using System.Security;
using System.Security.Claims;
using System.Security.Permissions;
using System.Threading;

namespace ClaimsBasedSecurityDemo
{
    class CustomAuthorisationManagerExample
    {
        public void Execute()
        {
            PrintHeader();
            Setup();

            try
            {
                TestPermissionsSuccess();
                TestPermissionsFail();
            }
            catch (SecurityException e)
            {
                Console.WriteLine("SecurityException: " + e.Message);
            }

            Console.WriteLine();
        }

        [ClaimsPrincipalPermission(SecurityAction.Demand, 
                                    Operation = "Add", 
                                    Resource = "Customer")]
        private void TestPermissionsSuccess()
        {
            Console.WriteLine("Code successfully runs!");
        }

        [ClaimsPrincipalPermission(SecurityAction.Demand,
                                    Operation = "Delete",
                                    Resource = "Customer")]
        private void TestPermissionsFail()
        {
            Console.WriteLine("We do not get here...");
        }


        private void Setup()
        {
            var myClaim = new Claim("http://myclaims/customer", "add");
            var currentIdentity = new CorpIdentity("stevenh", myClaim);
            var principal = new ClaimsPrincipal(currentIdentity);
            Thread.CurrentPrincipal = principal;
        }

        private void PrintHeader()
        {
            Console.WriteLine("Custom Authorisation Manager Examples");
            Console.WriteLine("_____________________________________");
            Console.WriteLine();
        }
    }
}
