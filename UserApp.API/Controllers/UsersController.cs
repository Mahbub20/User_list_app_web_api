using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserApp.Application.Models;
using UserApp.Infrastructure.Repositories;

namespace UserApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] UserQueryParams query)
        {
            var (users, total) = await _repo.GetUsers(query);

            return Ok(new
            {
                data = users,
                total,
                page = query.Page,
                pageSize = query.PageSize
            });
        }
    }
}