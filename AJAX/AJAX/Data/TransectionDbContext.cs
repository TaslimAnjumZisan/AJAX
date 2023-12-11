using AJAX.Models;
using Microsoft.EntityFrameworkCore;

namespace AJAX.Data
{
    public class TransectionDbContext:DbContext
    {
        public TransectionDbContext(DbContextOptions<TransectionDbContext> options) : base(options) { }

        public DbSet<TransectionModel> Transections { get; set; }
    }
}
