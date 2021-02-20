using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RP_PELICULAS.Data;
using RP_PELICULAS.Modelos;

namespace RP_PELICULAS.Pages.Peliculas
{
    public class DetailsModel : PageModel
    {
        private readonly RP_PELICULAS.Data.RP_PELICULASContext _context;

        public DetailsModel(RP_PELICULAS.Data.RP_PELICULASContext context)
        {
            _context = context;
        }

        public Pelicula Pelicula { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pelicula = await _context.Pelicula.FirstOrDefaultAsync(m => m.Id == id);

            if (Pelicula == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
