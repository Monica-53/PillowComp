using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PillowComp.Models;

namespace PillowComp.Data
{
    public class PillowCompContext : DbContext
    {
        public PillowCompContext (DbContextOptions<PillowCompContext> options)
            : base(options)
        {
        }

        public DbSet<PillowComp.Models.Pillow> Pillow { get; set; }
    }
}
