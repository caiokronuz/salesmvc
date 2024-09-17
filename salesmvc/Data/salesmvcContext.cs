using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using salesmvc.Models;

namespace salesmvc.Data
{
    public class salesmvcContext : DbContext
    {
        public salesmvcContext (DbContextOptions<salesmvcContext> options)
            : base(options)
        {
        }

        public DbSet<salesmvc.Models.Department> Department { get; set; } = default!;
    }
}
