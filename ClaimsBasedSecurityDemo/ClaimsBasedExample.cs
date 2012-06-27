using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace ClaimsBasedSecurityDemo
{
    class ClaimsBasedExample
    {
        public void Execute()
        {
            PrintHeader();

            Setup();
            UseLegacyStyle();
            UseNewStyle();
        }

        private void UseNewStyle()
        {
            //var principal = Thread.CurrentPrincipal;
            //var claimsPrincipal = principal as ClaimsPrincipal;
            
            // this line replaces the two above
            var claimsPrincipal = ClaimsPrincipal.Current;

            var email = claimsPrincipal.FindFirst(ClaimTypes.Email).Value;
            Console.WriteLine(email);
            
            Console.WriteLine();
        }

        private void UseLegacyStyle()
        {
            var principal = Thread.CurrentPrincipal;
            Console.WriteLine("Principal Name: " + principal.Identity.Name);
            Console.WriteLine("IsInRole('Geek'): " + principal.IsInRole("Geek"));
        }

        private void Setup()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "stevenh"),
                new Claim(ClaimTypes.Email, "me@hotmail.com"),
                new Claim(ClaimTypes.Role, "Geek"),
                new Claim("http://myclaims/location", "London")
            };

            var id = new ClaimsIdentity(claims, "My App");
            Console.WriteLine("IsAuthenticated: " + id.IsAuthenticated);

            var principal = new ClaimsPrincipal(id);
            Thread.CurrentPrincipal = principal;
        }

        private void PrintHeader()
        {
            Console.WriteLine("Claims Based Examples");
            Console.WriteLine("_____________________");
            Console.WriteLine();
        }
    }
}
