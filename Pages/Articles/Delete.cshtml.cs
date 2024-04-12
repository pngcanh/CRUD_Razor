using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Razor.Pages_Articles
{
    public class DeleteModel : PageModel
    {
        private readonly MyBlogContext _context;

        public DeleteModel(MyBlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Articles Articles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles.FirstOrDefaultAsync(m => m.ArticleID == id);

            if (articles == null)
            {
                return NotFound();
            }
            else
            {
                Articles = articles;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _context.Articles.FindAsync(id);
            if (articles != null)
            {
                Articles = articles;
                _context.Articles.Remove(Articles);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexArticle");
        }
    }
}
