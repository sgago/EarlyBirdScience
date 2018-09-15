using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EarlyBirdScience.Models
{
    public class EarlyBirdScienceContext : DbContext
    {
        public EarlyBirdScienceContext (DbContextOptions<EarlyBirdScienceContext> options)
            : base(options)
        {
        }

        public DbSet<EarlyBirdScience.Models.PostModel> PostModel { get; set; }
    }
}
