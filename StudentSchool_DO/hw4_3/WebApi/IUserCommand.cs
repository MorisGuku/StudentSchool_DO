using WebApi;
using WebApi.Validators;

namespace hw_2.WebApi;

public interface IUserCommand

{
  List<UserDto> GetUsers();
  UserDto Get(Guid id);
  UserCreateResponse Create(UserCreateDto request);
  bool Update(Guid id, UserUpdateDto request);
  bool Delete(Guid id);
}
