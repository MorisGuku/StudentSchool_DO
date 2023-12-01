using DbModel;

namespace hw_2.WebApi;

public interface IUserMapDto
{
  UserDto Map(DbUser dbUser);
}
