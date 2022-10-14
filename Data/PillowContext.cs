using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PillowComp.Models;
using Microsoft.EntityFrameworkCore;

namespace PillowComp.Data
{
    public class PillowContext : DbContext
    {
        public PillowContext(DbContextOptions<PillowContext> options)
          : base(options)
        {
        }

        public DbSet<Pillow> Pillow { get; set; }
    }
}
