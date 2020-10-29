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
    public class IndexModel : PageModel
    {
        private readonly DogTraining.Data.DogTrainingContext _context;

        public IndexModel(DogTraining.Data.DogTrainingContext context)
        {
            _context = context;
        }

        public IList<Trainer> Trainer { get;set; }

        public async Task OnGetAsync()
        {
            Trainer = await _context.Trainer.ToListAsync();
        }
    }
}
