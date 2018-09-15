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
    public class DeleteModel : PageModel
    {
        private readonly EarlyBirdScience.Models.EarlyBirdScienceContext _context;

        public DeleteModel(EarlyBirdScience.Models.EarlyBirdScienceContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PostModel = await _context.PostModel.FindAsync(id);

            if (PostModel != null)
            {
                _context.PostModel.Remove(PostModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
