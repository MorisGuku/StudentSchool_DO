namespace hw_2.WebApi;

public interface IPersonActions
{
  Guid Create(PersonInfo request);
  PersonInfo Get(Guid id);
}
