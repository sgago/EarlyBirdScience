using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EarlyBirdScience.Models;

namespace EarlyBirdScience.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly EarlyBirdScience.Models.EarlyBirdScienceContext _context;

        public CreateModel(EarlyBirdScience.Models.EarlyBirdScienceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PostModel PostModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PostModel.Add(PostModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}