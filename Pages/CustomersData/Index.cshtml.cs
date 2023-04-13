using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManager.Data;
using CustomerManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace CustomerManager.Pages.CustomersData
{
       
    public class IndexModel : PageModel
    {
        private readonly CustomerManager.Data.ApplicationDbContext _context;

        public IndexModel(CustomerManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CustomerData> CustomerData { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CustomerData != null)
            {
                CustomerData = await _context.CustomerData.ToListAsync();
            }
        }
    }
}
