using DataCaptureApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DataCaptureApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<UserData> UserData { get; set; }
    }
}