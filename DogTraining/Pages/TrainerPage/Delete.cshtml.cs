using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogTraining.Data;
using DogTraining.Models;

namespace DogTraining.Pages.TrainerPage
{
    public class DeleteModel : PageModel
    {
        private readonly DogTraining.Data.DogTrainingContext _context;

        public DeleteModel(DogTraining.Data.DogTrainingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trainer Trainer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trainer = await _context.Trainer.FirstOrDefaultAsync(m => m.TrainerID == id);

            if (Trainer == null)
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

            Trainer = await _context.Trainer.FindAsync(id);

            if (Trainer != null)
            {
                _context.Trainer.Remove(Trainer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
