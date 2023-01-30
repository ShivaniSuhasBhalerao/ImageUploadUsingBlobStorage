using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.Account.Web;

namespace YogapointVersion_1.Pages.Account
{
    public class CustomLoginModel : LoginModel
    {
        public CustomLoginModel(IAuthenticationSchemeProvider schemeProvider,
            IOptions<AbpAccountOptions> accountOptions,
            IOptions<IdentityOptions> identityOptions)
            : base(schemeProvider, accountOptions, identityOptions)
        {
        }
    }
}
