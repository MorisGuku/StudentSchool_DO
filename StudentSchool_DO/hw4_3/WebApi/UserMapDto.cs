using DbModel;
using hw_2.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2.WebApi
{
    public class UserMapDto : IUserMapDto
    {
        public UserDto Map(DbUser dbUser)
        {
            return new UserDto
            {
                UserId = dbUser.UserId,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                CreatedTime = dbUser.CreatedTime
            };
        }

    }
}
