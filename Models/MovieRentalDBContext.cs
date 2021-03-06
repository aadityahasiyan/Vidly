using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieRentalDBContext : IdentityDbContext<ApplicationUser>
    {
        public MovieRentalDBContext()
        {

        }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public static MovieRentalDBContext Create()
        {
            return new MovieRentalDBContext();
        }
    }
}