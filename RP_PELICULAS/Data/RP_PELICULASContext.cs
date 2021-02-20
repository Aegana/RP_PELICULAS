using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RP_PELICULAS.Modelos;

namespace RP_PELICULAS.Data
{
    public class RP_PELICULASContext : DbContext
    {
        public RP_PELICULASContext (DbContextOptions<RP_PELICULASContext> options)
            : base(options)
        {
        }

        public DbSet<RP_PELICULAS.Modelos.Pelicula> Pelicula { get; set; }
    }
}
