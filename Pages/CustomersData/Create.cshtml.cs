using Microsoft.AspNetCore.Mvc;
using CustomerManager.Data;
using CustomerManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CustomerManager.Authorization;

namespace CustomerManager.Pages.CustomersData
{
    public class CreateModel : DI_BasePageModel
    {
        public CreateModel(ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {            
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerData CustomerData { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            CustomerData.CreatorId = UserManager.GetUserId(User);

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, CustomerData, CustomerDataOperations.Create);

            if (isAuthorized.Succeeded == false)
                return Forbid();
          

            Context.CustomerData.Add(CustomerData);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
