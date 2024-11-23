using Microsoft.EntityFrameworkCore;
using BlueAgenda.Models;

namespace BlueAgenda.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<AgendaModel> Agenda { get; set; }
    }

}