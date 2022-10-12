using CrudApp.DataAccess;
using CrudApp.Models;

namespace CrudApp.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly UserContext _context;

    public UserService(UserContext context, ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IEnumerable<User> GetUsers()
    {
        _logger.LogInformation("Get all users");
        return _context.Users.ToList();
    }

    public User GetById(long id)
    {
        _logger.LogInformation("Get user by id: {UserId}", id);
        return GetUser(id);
    }

    private User GetUser(long id)
    {
        var user = _context.Users.Find(id);
        return user ?? throw new KeyNotFoundException("User not found.");
    }

    public User CreateOrUpdate(User user)
    {
        _logger.LogInformation("Create or update user: {UserId}", user.Id);

        var existingUser = _context.Users.Find(user.Id);

        if (existingUser is null)
        {
            _context.Users.Add(user);
        }
        else
        {
            existingUser.Email = user.Email;
            existingUser.Name = user.Name;
        }

        _context.SaveChanges();
        return user;
    }

    public void Delete(long id)
    {
        _logger.LogInformation("Delete user: {UserId}", id);

        var user = GetUser(id);

        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}
