using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Account.Web.Pages.Account;

namespace YogapointVersion_1.Pages.Account
{
    public class CustomResetPasswordConfirmation : ResetPasswordConfirmationModel
    {
        [BindProperty()]
        public new string ReturnUrl { get; set; }

        [BindProperty()]
        public new string ReturnUrlHash { get; set; }

        public override Task<IActionResult> OnGetAsync()
        {
            ReturnUrl = GetRedirectUrl(ReturnUrl, ReturnUrlHash);

            return Task.FromResult<IActionResult>(Page());
        }

    }
}
