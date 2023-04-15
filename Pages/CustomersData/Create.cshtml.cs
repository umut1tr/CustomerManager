using Microsoft.AspNetCore.Mvc;
using CustomerManager.Data;
using CustomerManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

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
          if (!ModelState.IsValid || Context.CustomerData == null || CustomerData == null)
            {
                return Page();
            }

            Context.CustomerData.Add(CustomerData);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
