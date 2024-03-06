using Microsoft.EntityFrameworkCore;
using ProdutoExempoApiSolid.Model;

namespace ProdutoExempoApiSolid.Data
{
    public class ProdutoDbContext : DbContext
    {

        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
