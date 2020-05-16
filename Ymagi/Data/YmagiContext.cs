using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ymagi.Models
{
    public class YmagiContext : IdentityDbContext
    {
        public YmagiContext (DbContextOptions<YmagiContext> options)
            : base(options)
        {
        }

        public DbSet<Osc> Osc { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Membro> Membro { get; set; }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Fornecedor> Fornecedor { get; set; }

        public DbSet<Entrega> Entrega { get; set; }

        public DbSet<Recebimento> Recebimento { get; set; }
    }
}
