
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreProject.Models {

    public class AppDbContext : DbContext  {

        public AppDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            var connStr = 
                "server=localhost\\sqlexpress;database=AppEfDb;trusted_connection=true;";
            builder.UseSqlServer(connStr);
        }
        public DbSet<Student> Students { get; set;  }
    }
}
