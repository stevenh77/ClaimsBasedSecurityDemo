using System;
using System.Security.Claims;
using System.Threading;

namespace ClaimsBasedSecurityDemo
{
    class CorpIdentityExample
    {
        public void Execute() 
        {

            PrintHeader();

            SetupCorpIdentity();
            UseCorpIdentity();
        }

        private void UseCorpIdentity()
        {
            var p = ClaimsPrincipal.Current;
            Console.WriteLine("Identity name: " + p.Identity.Name);
            Console.WriteLine("First Role:  " + p.FindFirst(ClaimTypes.Role).Value);
            Console.WriteLine();
        }

        private void SetupCorpIdentity()
        {
            var currentIdentity = new CorpIdentity("stevenh", "big boss", "zurich", "developer");
            var principal = new ClaimsPrincipal(currentIdentity);
            Thread.CurrentPrincipal = principal;
        }

        private void PrintHeader()
        {
            Console.WriteLine("Corp Identity Examples");
            Console.WriteLine("_____________________");
            Console.WriteLine();
        }
    }

    class CorpIdentity : ClaimsIdentity
    {
        private string p;
        private Claim myClaim;

        public CorpIdentity(string name, string reportsTo, string office, string role)
        {
            AddClaim(new Claim(ClaimTypes.Name, name));
            AddClaim(new Claim("reportsto", reportsTo));
            AddClaim(new Claim("office", office));
            AddClaim(new Claim(ClaimTypes.Role, role));
        }

        public CorpIdentity(string name, Claim claim)
        {
            AddClaim(new Claim(ClaimTypes.Name, name));
            AddClaim(claim);
        }

        public string ReportsTo
        {
            get { return FindFirst("reportsto").Value; }
        }
    }
}
