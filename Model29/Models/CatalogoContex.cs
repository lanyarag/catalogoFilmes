using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Model29.Models
{
    public class CatalogoContex: DbContext
    {
        public CatalogoContex(DbContextOptions<CatalogoContex> options) : base(options) { }
        public DbSet<FilmeModel> Catalogo { get; set; }
        public DbSet<AtorModel> Elenco { get; set; }
    }
}


