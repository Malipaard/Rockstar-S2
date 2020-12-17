using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ITtrainees.Models;
using Microsoft.Extensions.Configuration;

namespace ITtrainees.DataAcces
{
    class ArticlesContext : DbContext
    {
        public ArticlesContext() : base()
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-FG0G0NE; Database = master; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article(1, "First Article", "Sem", "Description of the article", "Tag", "Encoded Image", "Encoded PDF"));
        }
    }
}
