
namespace ClaimsBasedSecurityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // .NET 1.0 -> 4.5 (role based security)
            new WindowsIdentityExample().Execute();
            new GenericIdentityExample().Execute();
            new PrincipalPermissionExample().Execute();

            // .NET 4.5 > (claims based security)
            new ClaimsBasedExample().Execute();
            new CorpIdentityExample().Execute();
            new CustomAuthorisationManagerExample().Execute();
        }
    }
}
