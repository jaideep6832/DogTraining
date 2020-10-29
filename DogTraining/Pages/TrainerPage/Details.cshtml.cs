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
    public class DetailsModel : PageModel
    {
        private readonly DogTraining.Data.DogTrainingContext _context;

        public DetailsModel(DogTraining.Data.DogTrainingContext context)
        {
            _context = context;
        }

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
    }
}
