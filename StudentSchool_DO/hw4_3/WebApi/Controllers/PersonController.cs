using Microsoft.AspNetCore.Mvc;

namespace hw_2.HwApi.Controllers;


[Route("[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
  private readonly OfficeDB _dbContext ;

  public UsersController(ApplicationDbContext context)
  {
    _context = context;
  }
  [HttpPost]
  public Guid Create(
    [FromServices] IPersonActions action,
    [FromBody] PersonInfo request)
  {
    return action.Create(request);
  }
}
