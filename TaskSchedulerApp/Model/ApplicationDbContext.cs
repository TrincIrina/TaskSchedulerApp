using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerApp.Model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Item> Items { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connectionString = @"
			    Data Source=HOME\SQLEXPRESS;
			    Initial Catalog=Task_Scheduler_db;
                Integrated Security = false;
                TrustServerCertificate=true;
			    Integrated Security=SSPI;
			    Timeout=5;
		    ";
            if (!options.IsConfigured)
            {
                options.UseSqlServer(connectionString, bilder => bilder.EnableRetryOnFailure());
            }
        }
    }
}
