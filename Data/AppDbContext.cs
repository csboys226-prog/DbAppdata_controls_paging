using Microsoft.EntityFrameworkCore;
using DbAppdata_controls_paging.Models;

namespace DbAppdata_controls_paging.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
    }
}