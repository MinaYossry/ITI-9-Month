using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Identity.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base("ConString") 
        {
        }

        public DbSet<User> Users { get; set; }
    }

}