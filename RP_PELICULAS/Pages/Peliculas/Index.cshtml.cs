using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RP_PELICULAS.Data;
using RP_PELICULAS.Modelos;

namespace RP_PELICULAS.Pages.Peliculas
{
    public class IndexModel : PageModel
    {
        private readonly RP_PELICULAS.Data.RP_PELICULASContext _context;

        public IndexModel(RP_PELICULAS.Data.RP_PELICULASContext context)
        {
            _context = context;
        }

        public IList<Pelicula> Pelicula { get;set; }
        [BindProperty(SupportsGet =true)]
        public string searchString { get; set; } //variable que se va a utilizar para guardar lo que el usuario ponga en el buscador
        public SelectList genero { get; set; } //lista con generos
        [BindProperty(SupportsGet = true)]
        public string generoPelicula { get; set; } //va ser el valor que elija el usuario al seleccionar un genero de la lista
        public async Task OnGetAsync()
        {
            var pelicula = from n in _context.Pelicula
                           select n;
            if (!string.IsNullOrEmpty(searchString))
            {
                pelicula = pelicula.Where(S => S.Titulo.Contains(searchString));
            }
            IQueryable<string> generoQuery = from m in _context.Pelicula
                                               orderby m.Genero
                                               select m.Genero;
            if (!string.IsNullOrEmpty(generoPelicula))
            {
                pelicula = pelicula.Where(s => s.Genero==generoPelicula);

            }
            genero = new SelectList(await generoQuery.Distinct().ToListAsync());
            // Pelicula = await _context.Pelicula.ToListAsync();
            Pelicula = await pelicula.ToListAsync(); //mostramos lo que hemos  filtrado en la variable que hemos creado, si no se busca nada, se muestra todo

        }
    }
}
