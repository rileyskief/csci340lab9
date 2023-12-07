using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StanfordUniversity.Data;
using StanfordUniversity.Models;

namespace StanfordUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly StanfordUniversity.Data.SchoolContext _context;

        public IndexModel(StanfordUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get; set; }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
