using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerManager.Data;
using CustomerManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CustomerManager.Authorization;

namespace CustomerManager.Pages.CustomersData
{
    public class EditModel : DI_BasePageModel
    {
        

        public EditModel(ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
            
        }

        [BindProperty]
        public CustomerData CustomerData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || Context.CustomerData == null)
            {
                return NotFound();
            }

            CustomerData =  await Context.CustomerData.FirstOrDefaultAsync(m => m.Id == id);

            if (CustomerData == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, CustomerData, CustomerDataOperations.Update);

            if (isAuthorized.Succeeded == false)
                return Forbid();


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Context.Attach(CustomerData).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDataExists(CustomerData.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerDataExists(int id)
        {
          return (Context.CustomerData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
