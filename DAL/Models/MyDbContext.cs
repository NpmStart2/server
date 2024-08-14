using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using dotenv.net;


namespace DAL.Models
{
    public class MyDbContext : DbContext, IContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            //DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../../.env.local"]));

            
            string connection = Environment.GetEnvironmentVariable("DB_CONNECTION");

            // בדיקה אם משתנה הסביבה נטען כראוי
            if (string.IsNullOrEmpty(connection))
            {
                throw new InvalidOperationException("Connection string not found in environment variables.");
            }

            optionsBuilder.UseSqlServer(connection);
        }
    }
}
