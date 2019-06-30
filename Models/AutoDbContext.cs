using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAPI.Models
{
    public class AutoDbContext: DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public AutoDbContext(DbContextOptions options): base(options){ }
    }
}
