using AutoMapper;
using DbModel;
using Microsoft.AspNetCore.Mvc.Infrastructure;
namespace hw_2.WebApi;

public class GetUsersCommand : IGetUserCommand
{
    private readonly IUserMapDto _mapper;

    public GetUsersCommand(IUserMapDto mapper)
    {
        _mapper = mapper;
    }
    public List<UserDto> GetUsers()
    {
        var userRepository = new UserRepository();
        var dbUsers = userRepository.GetUsersEF();
        List<UserDto> dtoUsers = new List<UserDto>();
        foreach (var user in dbUsers)
        {
           dtoUsers.Add(_mapper.Map(user));
        }
        return dtoUsers;
    }
    public UserDto Get(Guid id)
    {
        var userRepository = new UserRepository();
        var dbUser = userRepository.GetUserEF(id);
        return _mapper.Map(dbUser);
    }
    public Guid Create(UserCreateDto request)
    {
        var userRepository = new UserRepository();
        userRepository.CreateUser(new DbUser { FirstName = request.FirstName, LastName = request.LastName });
        var user = userRepository.GetUsersEF();
        var id = user.OrderByDescending(u => u.CreatedTime).Select(u => u.UserId).FirstOrDefault();
        var dbUser = userRepository.GetUserEF(id);
        return dbUser.UserId;
    }
    public bool Update(Guid id, UserUpdateDto request)
    {
        var userRepository = new UserRepository();
        userRepository.EditUser(id, request.FirstName, request.LastName, request.CarId);
        return true;
    }
    public bool Delete(Guid id)
    {
        var userRepository = new UserRepository();
        userRepository.DeleteUser(id);
        return true;
    }
}
//public class GetUsersCommand : IGetUsersCommand
//{
//    static Dictionary<Guid, DbUser> users = new();
//    private readonly IMapper _mapper;

//    public GetUsersCommand(IMapper mapper)
//    {
//        _mapper = mapper;
//    }

//    public UsersDtoInfo Get(Guid id)
//    {
//        var userRepository = new UserRepository();
//        var dbUser = userRepository.GetUserEF(id);
//        var user = _mapper.Map(dbUser);
//        return user[id];


//    }
//}

