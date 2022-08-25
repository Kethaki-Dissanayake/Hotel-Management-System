using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class MyContext : DbContext


    {
        public MyContext(DbContextOptions<MyContext> options)
            :base(options)
        {

        }

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Features> Features { get; set; }


    }
}
