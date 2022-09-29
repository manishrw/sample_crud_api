using Microsoft.EntityFrameworkCore;
using CrudApp.Models;

namespace CrudApp.DataAccess;

public class UserContext : DbContext
{
    private readonly ILogger<UserContext> _logger;

    protected readonly IConfiguration Configuration;

    public UserContext(IConfiguration configuration, DbContextOptions<UserContext> options, ILogger<UserContext> logger)
        : base(options)
    {
        Configuration = configuration;
        _logger = logger;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<User> Users { get; set; }
}