using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DogTraining.Training;
using DogTraining.Models;

namespace DogTraining.Data
{
    public class DogTrainingContext : DbContext
    {
        public DogTrainingContext (DbContextOptions<DogTrainingContext> options)
            : base(options)
        {
        }

        public DbSet<DogTraining.Training.Dog> Dog { get; set; }

        public DbSet<DogTraining.Training.Schedule> Schedule { get; set; }

        public DbSet<DogTraining.Models.Trainer> Trainer { get; set; }
    }
}
