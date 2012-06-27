using System.Security.Claims;
using System.Linq;

namespace ClaimsBasedSecurityDemo
{
    class AuthorisationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            var resource = context.Resource.First().Value;
            var action = context.Action.First().Value;

            // hardcoded rules could be replaced by injection or load from xml
            if (resource == "Customer" && action == "Add")
            {
                var hasAccess = context.Principal.HasClaim("http://myclaims/customer", "add");
                return hasAccess;
            }

            return false;
        }
    }
}
