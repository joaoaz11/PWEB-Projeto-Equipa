using Microsoft.EntityFrameworkCore;

namespace ufcd10789_Tarefa06.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Equipa> Equipas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@"Data Source=_BaseDeDados.db");
    }
}
