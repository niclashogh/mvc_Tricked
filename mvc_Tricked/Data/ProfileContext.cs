using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc_Tricked.Models;

namespace mvc_Tricked.Data
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options)
            : base(options)
        {
        }

        public DbSet<mvc_Tricked.Models.Profile> Profile { get; set; } = default!;
    }
}