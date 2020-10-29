using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DogTraining.Data;
using DogTraining.Models;

namespace DogTraining.Pages.TrainerPage
{
    public class CreateModel : PageModel
    {
        private readonly DogTraining.Data.DogTrainingContext _context;

        public CreateModel(DogTraining.Data.DogTrainingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Trainer Trainer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trainer.Add(Trainer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
