using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApp.Application.DTOs;
using UserApp.Application.Models;

namespace UserApp.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public Task<(List<UserDto>, int)> GetUsers(UserQueryParams query);
    }
}