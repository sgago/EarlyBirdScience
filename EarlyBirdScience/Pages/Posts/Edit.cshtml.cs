using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EarlyBirdScience.Models;

namespace EarlyBirdScience.Pages.Posts
{
    public class EditModel : PageModel
    {
        private readonly EarlyBirdScience.Models.EarlyBirdScienceContext _context;

        public EditModel(EarlyBirdScience.Models.EarlyBirdScienceContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PostModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostModelExists(PostModel.PostId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PostModelExists(int id)
        {
            return _context.PostModel.Any(e => e.PostId == id);
        }
    }
}
