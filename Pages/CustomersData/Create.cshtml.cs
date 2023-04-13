using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomerManager.Data;
using CustomerManager.Models;

namespace CustomerManager.Pages.CustomersData
{
    public class CreateModel : PageModel
    {
        private readonly CustomerManager.Data.ApplicationDbContext _context;

        public CreateModel(CustomerManager.Data.ApplicationDbContext context)
        {
            _context = context;
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
          if (!ModelState.IsValid || _context.CustomerData == null || CustomerData == null)
            {
                return Page();
            }

            _context.CustomerData.Add(CustomerData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
