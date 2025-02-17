using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Razor.Pages_Categories
{
    public class DeleteModel : PageModel
    {
        private readonly MyBlogContext _context;

        public DeleteModel(MyBlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categories Categories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryID == id);

            if (categories == null)
            {
                return NotFound();
            }
            else
            {
                Categories = categories;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.FindAsync(id);
            if (categories != null)
            {
                Categories = categories;
                _context.Categories.Remove(Categories);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Categories/IndexCate");
        }
    }
}
