using Microsoft.EntityFrameworkCore;
using MvcVeterinaria.Models;

namespace MvcVeterinaria.Data{

    public class MvcVeterinariaContext: DbContext
    {
        public MvcVeterinariaContext(DbContextOptions<MvcVeterinariaContext> options)
        :base(options)
        {
        }
       public DbSet<Veterinario> Veterinario {get; set;}
       public DbSet<Medicamento> Medicamento { get; set; }
       public DbSet<Cita> Cita { get; set; }
    }
}