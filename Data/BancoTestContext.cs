using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TesteAluno.Models;

namespace TesteAluno.Data
{
    public class BancoTestContext : IdentityDbContext
    {
        public BancoTestContext(DbContextOptions<BancoTestContext> options) : base (options) { }

        public DbSet<Aluno> Aluno { get; set; }
    }
}
