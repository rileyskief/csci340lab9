using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StanfordUniversity.Data;
using StanfordUniversity.Models;

namespace StanfordUniversity.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly StanfordUniversity.Data.SchoolContext _context;

        public IndexModel(StanfordUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Department = await _context.Departments
                .Include(d => d.Administrator).ToListAsync();
        }
    }
}
