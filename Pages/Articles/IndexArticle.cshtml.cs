using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP_Razor.Pages_Articles
{
    public class IndexModel : PageModel
    {
        private readonly MyBlogContext _context;

        public IndexModel(MyBlogContext context)
        {
            _context = context;
        }

        public IList<Articles> Articles { get; set; } = default!;

        public async Task OnGetAsync(string SearchString)
        {
            var qr = from a in _context.Articles
                     orderby a.Created descending
                     select a;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Articles = qr.Where(a => a.Title.Contains(SearchString)).ToList();
            }
            else
            {
                Articles = await qr.ToListAsync();
            }
            // Articles = await _context.Articles.ToListAsync();
        }
    }
}
