using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DbAppdata_controls_paging.Data;
using DbAppdata_controls_paging.Models;

namespace DbAppdata_controls_paging.Pages
{
    public class IndexModel(AppDbContext context) : PageModel
    {
        private readonly AppDbContext _context = context;

        public List<Student> Students { get; set; } = new();
        public string CurrentSort { get; set; } = string.Empty;
        public int CurrentPage { get; set; }

        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {
            CurrentSort = sortOrder;
            CurrentPage = pageIndex ?? 1;
            int pageSize = 3; // Number of items per page

            // Seed data if empty
            if (!_context.Students.Any())
            {
                _context.Students.AddRange(
                    new Student { Name = "Arun", Grade = "A" },
                    new Student { Name = "Zakir", Grade = "B" },
                    new Student { Name = "Baskar", Grade = "C" },
                    new Student { Name = "Dinesh", Grade = "A" },
                    new Student { Name = "Charu", Grade = "B" }
                );
                await _context.SaveChangesAsync();
            }

            IQueryable<Student> studentIQ = from s in _context.Students select s;

            // 1. Sorting Logic
            studentIQ = sortOrder == "name_desc" ? studentIQ.OrderByDescending(s => s.Name) : studentIQ.OrderBy(s => s.Name);

            // 2. Paging Logic
            Students = await studentIQ
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}