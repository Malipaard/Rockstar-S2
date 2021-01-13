using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ITtrainees.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AnsweredQuestion> AnsweredQuestions { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new
                ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",
                optional: true, reloadOnChange: true);

            optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var hasher = new PasswordHasher<Account>();
            
            var Admin = new Account(1,"Admin",0,true,"temp");

            Admin.Password = hasher.HashPassword(Admin, "Admin123");

            modelBuilder.Entity<Account>().HasData(Admin);
        }
    }
}
