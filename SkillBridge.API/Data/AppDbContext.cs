using Microsoft.EntityFrameworkCore;
using SkillBridge.API.Models;

namespace SkillBridge.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<PlanoDesenvolvimento> PlanosDesenvolvimento { get; set; }
    }
}