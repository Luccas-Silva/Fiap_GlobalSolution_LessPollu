using LessPollu.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LessPollu.MVC.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<RelatorioEntity> Relatorio { get; set; }
        public DbSet<IndustriaEntity> Industria { get; set; }

    }
}
