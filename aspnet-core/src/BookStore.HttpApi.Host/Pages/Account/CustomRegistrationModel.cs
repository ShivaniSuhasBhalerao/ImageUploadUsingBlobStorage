using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YogapointVersion_1.UserExtraProperties;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Settings;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Settings;
using Volo.Abp.Validation;

using static YogapointVersion_1.Pages.Account.CustomRegistrationModel;
using static Volo.Abp.Account.Web.Pages.Account.RegisterModel;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
namespace YogapointVersion_1.Pages.Account
{
    public class CustomRegistrationModel : RegisterModel
    {
        [BindProperty]
        public Inputdata Input { get; set; }

        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly ILookupNormalizer _lookupNormalizer;
        public CustomRegistrationModel(IAccountAppService accountAppService, IIdentityUserRepository identityUserRepository, ILookupNormalizer lookupNormalizer) : base(accountAppService)
        {
            // Input = new();
            // Input.Name = Faker.Name.First();
            // Input.Surname = Faker.Name.Last();
            //Input.UserName = Faker.Name.First();
            //Input.EmailAddress = Faker.Internet.Email(Input.UserName);
            // Input.Gender = (char)Faker.Enum.Random<Gender>();
            _identityUserRepository = identityUserRepository;
            _lookupNormalizer = lookupNormalizer;
        }

        public class IdentityUserExtraProperties : IdentityUser
        {
            public IdentityUserExtraProperties(Guid id, string userName, string email, string _Name, string _Surname, Guid? tenantId = null) : base(id, userName, email, tenantId)
            {
                Name = _Name;
                Surname = _Surname;
            }
        }
        protected override async Task RegisterLocalUserAsync()
        {
            ValidateModel();
            var userDto = await RegisterAsync(
    new CustRegDTO
    {
        AppName = "MVC",
        EmailAddress = Input.EmailAddress,
        Password = Input.Password,
        UserName = Input.Name,
        Gender = Input.Gender,
        Name = Input.Name,
        Surname = Input.Surname,
        Title = Input.Title,


    }
);
            var user = await UserManager.GetByIdAsync(userDto.Id);
            await SignInManager.SignInAsync(user, isPersistent: true);
        }
        public virtual async Task<IdentityUserDto> RegisterAsync(CustRegDTO input)
        {
            await CheckSelfRegistrationAsync();


            await IdentityOptions.SetAsync();

            var user = new IdentityUserExtraProperties(GuidGenerator.Create(), input.UserName, input.EmailAddress, input.Name, input.Surname, CurrentTenant.Id);
            user.SetProperty(AbpUserExtraProperties.GenderPropertyTitle, input.Gender.ToString());
           // user.SetProperty(AbpUserExtraProperties.TitleProperty, input.Title);
            input.MapExtraPropertiesTo(user);
            (await UserManager.CreateAsync(user, input.Password)).CheckErrors();
            (await UserManager.AddDefaultRolesAsync(user)).CheckErrors();
            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
        }
       // public override async Task<IActionResult> OnPostAsync()
        //{
        //    var result = await base.OnPostAsync();
        //    var user = await _identityUserRepository.FindByNormalizedEmailAsync(_lookupNormalizer.NormalizeEmail(Input.EmailAddress));
        //    user.Name = Input.Name;
        //    user.Surname = Input.Surname;


        //    await _identityUserRepository.UpdateAsync(user);
        //    return result;
        //}

    }




    public class CustRegDTO : RegisterDto
    {


        public char Gender { get; set; }
        public string Title { get; set; }


        public string Name { get; set; }
        public string Surname { get; set; }

    }


    public enum Gender
    {
        Male = 'M',
        Female = 'F',
        Other = 'O'
    }
    public enum Title
    {
        Mr,
        Miss,
        Ms,
        Dr,
        Master
    }



    public class Inputdata : PostInput
    {

        public char Gender { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [NotMapped]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }

    }
}