using Microsoft.EntityFrameworkCore;
using CrudApp.Models;

namespace CrudApp.DataAccess;

public class UserContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DbSet<User> Users { get; set; } = null!;

    public UserContext(IConfiguration configuration, DbContextOptions<UserContext> options)
        : base(options)
        => Configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }
}
