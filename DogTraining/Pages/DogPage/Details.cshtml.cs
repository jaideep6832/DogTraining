using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DogTraining.Data;
using DogTraining.Training;

namespace DogTraining.Pages.DogPage
{
    public class DetailsModel : PageModel
    {
        private readonly DogTraining.Data.DogTrainingContext _context;

        public DetailsModel(DogTraining.Data.DogTrainingContext context)
        {
            _context = context;
        }

        public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dog.FirstOrDefaultAsync(m => m.DogID == id);

            if (Dog == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
