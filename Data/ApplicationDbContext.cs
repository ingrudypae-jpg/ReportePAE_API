using Microsoft.EntityFrameworkCore;
using ReportePAE_API.Models;

namespace ReportePAE_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ReporteSOS> ReportesSOS { get; set; }
    }
}
