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
    public ActionResult<IEnumerable<User>> Get()
    {
        var users = _userService.GetUsers();

        _logger.LogInformation("Get users {@Users}", users);

        return Ok(users);
    }

    [HttpPut]
    public ActionResult<User> Put(User user)
    {
        _logger.LogInformation("Put user: {@User}", user);

        var updated = _userService.CreateOrUpdate(user);

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _logger.LogInformation("Delete user: {UserId}", id);

        try
        {
            _userService.Delete(id);
            return NoContent();
        }
        catch (KeyNotFoundException keyNotFoundException)
        {
            return NotFound(keyNotFoundException.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(long id)
    {
        _logger.LogInformation("Get user: {UserId}", id);

        try
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
        catch (KeyNotFoundException keyNotFoundException)
        {
            return NotFound(keyNotFoundException.Message);
        }
    }
}
