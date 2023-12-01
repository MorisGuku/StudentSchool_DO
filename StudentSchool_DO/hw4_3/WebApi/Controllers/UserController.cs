using hw_2.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  [HttpGet]
  public  List<UserDto> GetUsers(
      [FromServices] IUserCommand command)
  {
      return command.GetUsers();
  }

  [HttpGet("{id}")]
  public  UserDto GetUser(
      [FromServices] IUserCommand command,
      [FromRoute] Guid id)
  {
      return command.Get(id);
  }

  [HttpPost]
  public UserCreateResponse Create(
    [FromServices] IUserCommand command,
    [FromBody] UserCreateDto request)
  {
    return command.Create(request);
  }

  [HttpPut("{id}")]
  public bool Update(
    [FromServices] IUserCommand command,
    [FromRoute] Guid id,
    [FromBody] UserUpdateDto request)
  {
    return command.Update(id, request);
  }

  [HttpDelete("{id}")]
  public bool Delete(
    [FromServices] IUserCommand command,
    [FromRoute] Guid id)
  {
    return command.Delete(id);
  }

}
