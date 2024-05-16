using Kontrola.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kontrola.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Gravidade> Gravidades { get; set; }
        public DbSet<ItemChamado> ItemChamados { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tendencia> Tendencias { get; set; }
        public DbSet<Urgencia> Urgencias { get; set; }



    }
}
