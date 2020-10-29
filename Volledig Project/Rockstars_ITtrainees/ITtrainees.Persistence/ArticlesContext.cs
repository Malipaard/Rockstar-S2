﻿using System;
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

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-7SORRU5A; Integrated Security=SSPI; Initial Catalog=TechBurstArticles;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article()
                {
                    ArticleId = 1,
                    Title = "First Article",
                    Author = "Sem",
                    Summary = "Description of the article"
                });
        }
    }
}
