using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP_Razor.Pages_Articles
{
    public class EditModel : PageModel
    {
        private readonly MyBlogContext _context;

        public EditModel(MyBlogContext context)
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
            Articles = articles;
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

            _context.Attach(Articles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticlesExists(Articles.ArticleID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./IndexArticle");
        }

        private bool ArticlesExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleID == id);
        }
    }
}
