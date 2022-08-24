using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class ContactContext : DbContext


    {
        public ContactContext(DbContextOptions<ContactContext> options)
            :base(options)
        {

        }

        public DbSet<Contacts> Contacts { get; set; }

        

    }
}
