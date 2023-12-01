namespace hw_2.WebApi;

public interface IGetUserCommand
{
  List<UserDto> GetUsers();
  UserDto Get(Guid id);
  Guid Create(UserCreateDto request);
  bool Update(Guid id, UserUpdateDto request);
  bool Delete(Guid id);
}
