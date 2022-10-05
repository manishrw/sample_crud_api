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
        var users = _userService.GetUsers();
		_logger.LogInformation("Get users {@users}", users);        
        return users;
    }

    [HttpPut]
    public User Put(User user)
    {
        _logger.LogInformation("Put user:{user}", user);
        return _userService.CreateOrUpdate(user);
    }

    [HttpDelete("{id}")]
    public void Delete(long id)
    {
        _logger.LogInformation("Delete user:{id}", id);
        _userService.Delete(id);
    }

    [HttpGet("{id}")]
    public User Get(long id)
    {
        _logger.LogInformation("Get user:{id}", id);
        return _userService.GetById(id);
    }
}
