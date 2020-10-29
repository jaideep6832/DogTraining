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
    public class IndexModel : PageModel
    {
        private readonly DogTraining.Data.DogTrainingContext _context;

        public IndexModel(DogTraining.Data.DogTrainingContext context)
        {
            _context = context;
        }

        public IList<Schedule> Schedule { get;set; }

        public async Task OnGetAsync()
        {
            Schedule = await _context.Schedule
                .Include(s => s.Dog)
                .Include(s => s.Trainer).ToListAsync();
        }
    }
}
