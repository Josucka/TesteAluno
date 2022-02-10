using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TesteAluno.Models;

namespace TesteAluno.Data
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BancoTestContext(serviceProvider.GetRequiredService<DbContextOptions<BancoTestContext>>()))
            {
                if (context.Aluno.Any())
                {
                    return;
                }
                context.SaveChanges();
            }
        }
    }
}
