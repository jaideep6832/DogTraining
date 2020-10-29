using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogTraining.Data;
using DogTraining.Training;

namespace DogTraining.Pages.SchedulePage
{
    public class DetailsModel : PageModel
    {
        private readonly DogTraining.Data.DogTrainingContext _context;

        public DetailsModel(DogTraining.Data.DogTrainingContext context)
        {
            _context = context;
        }

        public Schedule Schedule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Schedule = await _context.Schedule
                .Include(s => s.Dog)
                .Include(s => s.Trainer).FirstOrDefaultAsync(m => m.SchedID == id);

            if (Schedule == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
