using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext
           (DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<City> City { get; set; }
    }
}
