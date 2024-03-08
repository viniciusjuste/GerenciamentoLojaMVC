using GerenciamentoLojaMVC.Models;
using Microsoft.EntityFrameworkCore;


namespace GerenciamentoLojaMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {        
        }

        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<FuncionariosModel> Funcionarios { get; set; }
    }
}
