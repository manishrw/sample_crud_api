using Microsoft.AspNetCore.Mvc;
using CrudApp.Services;
using CrudApp.Models;

namespace CrudApp.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        _logger.LogInformation("Get users");
        _logger.LogInformation(_userService.GetUsers().ToString());
        // return Enumerable.Range(1, 5)
        // .Select(index => new User(Convert.ToInt64(index), "email" + index + "@a.com", "User" + index))
        // .ToArray();
        return _userService.GetUsers();
    }

    [HttpPut]
    public User Put(User user)
    {
        _logger.LogInformation($"Put user:{user}");
        return _userService.CreateOrUpdate(user);
    }
}
