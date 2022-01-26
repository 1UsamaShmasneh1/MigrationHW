using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MigrationHW.Models
{
    public partial class SomeDBContext : DbContext
    {
        public SomeDBContext()
        {
        }

        public SomeDBContext(DbContextOptions<SomeDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-UUKIMMC\\SQLEXPRESS;Initial Catalog=SomeDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Player>()
                .Property(p => p.Player_Name)
                .HasMaxLength(50);
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team);
            modelBuilder.Entity<Team>()
                .Property(p => p.Team_Title)
                .HasMaxLength(50);
            modelBuilder.Entity<Team>()
                .HasMany<Player>(p => p.Players);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
