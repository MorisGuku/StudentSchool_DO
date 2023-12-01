using Azure;
using DbModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi;
using WebApi.Validators;
using ValidationResult = WebApi.Validators.ValidationResult;

namespace hw_2.WebApi;

public class UserCommand : IUserCommand
{
    private readonly IUserMapDto _mapper;
    private readonly IValidator<UserCreateDto> _validator;
    public UserCommand(IUserMapDto mapper, IValidator<UserCreateDto> validator)
    {
        _mapper = mapper;
        _validator = validator;
    }

    public List<UserDto> GetUsers()
    {
        var userRepository = new UserRepository();
        var dbUsers = userRepository.GetUsersEF();
        return dbUsers.ConvertAll(_mapper.Map);
    }

    public UserDto Get(Guid id)
    {
        var userRepository = new UserRepository();
        var dbUser = userRepository.GetUserEF(id);
        return _mapper.Map(dbUser);
    }

    public UserCreateResponse Create(UserCreateDto request)
    {
        ValidationResult validationResult = _validator.Validate(request);
        UserCreateResponse response = new();
        if (!validationResult.IsValid)
        {
            response.Errors = validationResult.Errors.ToList();
        }
        else
        {
            var userRepository = new UserRepository();
            userRepository.CreateUser(new DbUser { FirstName = request.FirstName, LastName = request.LastName });
            var user = userRepository.GetUsersEF();
            var id = user.OrderByDescending(u => u.CreatedTime).Select(u => u.UserId).FirstOrDefault();
            var dbUser = userRepository.GetUserEF(id);
            response.Id = dbUser.UserId;
        }

        return response;
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
