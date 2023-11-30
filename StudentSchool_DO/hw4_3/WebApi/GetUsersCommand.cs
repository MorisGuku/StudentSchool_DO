using Microsoft.AspNetCore.Mvc.Infrastructure;
namespace hw_2.WebApi;

public class PersonActions : IPersonActions
{
  static Dictionary<Guid, PersonInfo> persons = new();
  private readonly IActionResultTypeMapper _mapper;

  public PersonActions(IActionResultTypeMapper mapper)
  {
    _mapper = mapper;
  }
  public Guid Create(PersonInfo request)
  {
    var id = Guid.NewGuid();
    persons.Add(id, request);
    return id;
  }

  public PersonInfo Get(Guid id)
  {
    return persons[id];
  }
}
