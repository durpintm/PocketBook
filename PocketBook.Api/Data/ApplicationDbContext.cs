using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PocketBook.Api.Models;

namespace PocketBook.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        // The dbset property will tell ef core that we have a table that needs to be created if it does not exist
        public virtual DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}