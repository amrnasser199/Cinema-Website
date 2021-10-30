using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using vidly.Models;

namespace Vidly.Models
{
    public class movieDB:DbContext
    {
        public DbSet<Movie> movies { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet <MembershipType>membershipTypes { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}