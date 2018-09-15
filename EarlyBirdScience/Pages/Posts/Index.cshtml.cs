using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EarlyBirdScience.Models;

namespace EarlyBirdScience.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly EarlyBirdScience.Models.EarlyBirdScienceContext _context;

        public IndexModel(EarlyBirdScience.Models.EarlyBirdScienceContext context)
        {
            _context = context;
        }

        public IList<PostModel> PostModel { get;set; }

        public async Task OnGetAsync()
        {
            PostModel = await _context.PostModel.ToListAsync();
        }
    }
}
