using DbModel;
using hw_2.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2
{
    public class UsersMapDto : IActionResultTypeMapper
    {
        private static UserDto Map(DbUser dbUser)
        {
            return new UserDto
            {
                UserId = dbUser.UserId,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                CreatedTime = dbUser.CreatedTime
            };
        }

        public IActionResult Convert(object? value, Type returnType)
        {
            throw new NotImplementedException();
        }

        public Type GetResultDataType(Type returnType)
        {
            throw new NotImplementedException();
        }
    }
}
