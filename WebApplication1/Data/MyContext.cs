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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Features_RoomTypes>()
                .HasOne(f => f.Features)
                .WithMany(fr => fr.Features_RoomTypes)
                .HasForeignKey(fi => fi.FeatureId);

            modelBuilder.Entity<Features_RoomTypes>()
                .HasOne(f => f.RoomTypes)
                .WithMany(fr => fr.Features_RoomTypes)
                .HasForeignKey(fi => fi.RoomTypeId);

        }

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Features> Features { get; set; }

        public DbSet<Prices> Prices { get; set; }

        public DbSet<RoomTypes> RoomTypes { get; set; }

        public DbSet<Features_RoomTypes> Features_RoomTypes { get; set; }

        public DbSet<PropertyInfos> PropertyInfos { get; set; }

        public DbSet<Rooms> Rooms { get; set; }

        public DbSet<Reservations> Reservations { get; set; }
    }
}
