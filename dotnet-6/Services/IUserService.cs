using CrudApp.Models;

namespace CrudApp.Services;

public interface IUserService
{
    IEnumerable<User> GetUsers();
    User GetById(long id);
    User CreateOrUpdate(User user);
    void Delete(long id);
}
