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
    public class DetailsModel : PageModel
    {
        private readonly EarlyBirdScience.Models.EarlyBirdScienceContext _context;

        public DetailsModel(EarlyBirdScience.Models.EarlyBirdScienceContext context)
        {
            _context = context;
        }

        public PostModel PostModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PostModel = await _context.PostModel.FirstOrDefaultAsync(m => m.PostId == id);

            if (PostModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
