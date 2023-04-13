using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManager.Data;
using CustomerManager.Models;

namespace CustomerManager.Pages.CustomersData
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerManager.Data.ApplicationDbContext _context;

        public DeleteModel(CustomerManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CustomerData CustomerData { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CustomerData == null)
            {
                return NotFound();
            }

            var customerdata = await _context.CustomerData.FirstOrDefaultAsync(m => m.Id == id);

            if (customerdata == null)
            {
                return NotFound();
            }
            else 
            {
                CustomerData = customerdata;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CustomerData == null)
            {
                return NotFound();
            }
            var customerdata = await _context.CustomerData.FindAsync(id);

            if (customerdata != null)
            {
                CustomerData = customerdata;
                _context.CustomerData.Remove(CustomerData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
