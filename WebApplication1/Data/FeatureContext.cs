using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class FeatureContext : DbContext


    {
        public FeatureContext(DbContextOptions<FeatureContext> options)
            :base(options)
        {

        }

        public DbSet<Features> Features { get; set; }

        

    }
}
