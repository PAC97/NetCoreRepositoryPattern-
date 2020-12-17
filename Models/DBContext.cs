using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VacantesApi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Carreras> Carreras { get; set; }
    }
}
