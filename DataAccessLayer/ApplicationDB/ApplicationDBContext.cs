using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NurseryWebApp.DataAccessLayer.ApplicationDB
{
    public class ApplicationDbContext : DbContext
    {       
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext() : base("name=ApplicationDbContext")
        {
            // This tells Entity Framework to use the connection string named 'ApplicationDbContext' from the web.config
        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}



