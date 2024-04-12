using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_Razor.Pages_Articles
{
    public class CreateModel : PageModel
    {
        private readonly MyBlogContext _context;

        public CreateModel(MyBlogContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Articles Articles { get; set; } = default!;
        // [BindProperty]
        // public Authors Authors { get; set; } = default!;
        // [BindProperty]
        // public Categories Categories { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            var authorList = from a in _context.Authors select a.AuthorID;
            bool authorListCheck = authorList.Any(item => item == Articles.AuID);
            var cateList = from a in _context.Categories select a.CategoryID;
            bool cateListCheck = cateList.Any(item => item == Articles.CateID);
            if (!ModelState.IsValid || !authorListCheck || !cateListCheck)
            {
                return Page();
            }
            else
            {
                _context.Articles.Add(Articles);
                await _context.SaveChangesAsync();
            }

            // ViewData["Authors"] = new SelectList(_context.Authors, "AuthorID", "AuthorName", Articles.AuthorID);
            // ViewData["Categories"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", Articles.CategoryID);

            return RedirectToPage("./IndexArticle");
        }
    }
}
