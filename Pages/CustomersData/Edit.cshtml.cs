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

namespace CustomerManager.Pages.CustomersData
{
    public class EditModel : PageModel
    {
        private readonly CustomerManager.Data.ApplicationDbContext _context;

        public EditModel(CustomerManager.Data.ApplicationDbContext context)
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

            var customerdata =  await _context.CustomerData.FirstOrDefaultAsync(m => m.Id == id);
            if (customerdata == null)
            {
                return NotFound();
            }
            CustomerData = customerdata;
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

            _context.Attach(CustomerData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
          return (_context.CustomerData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
