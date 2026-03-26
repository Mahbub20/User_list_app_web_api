using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApp.Application.DTOs;
using UserApp.Application.Models;
using UserApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace UserApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public UserRepository(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _connectionString = config.GetConnectionString("Default");
        }
        public async Task<(List<UserDto>, int)> GetUsers(UserQueryParams query)
        {
            var usersQuery = _context.Users.AsQueryable();

            //Filtering
            if (!string.IsNullOrEmpty(query.Search))
            {
                var search = query.Search.Trim().ToLower();
                usersQuery = usersQuery.Where(u =>
                    u.Name.ToLower().Contains(search) ||
                    u.Email.ToLower().Contains(search));
            }

            if (query.IsActive.HasValue)
            {
                usersQuery = usersQuery.Where(u => u.IsActive == query.IsActive);
            }

            // 📄 Pagination + DTO
            var users = await usersQuery
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    IsActive = u.IsActive
                })
                .ToListAsync();

            // ⚡ ADO.NET COUNT QUERY
            int totalCount = 0;

            using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            // var sql = "SELECT COUNT(*) FROM \"Users\""; // simplified for speed

            var sql = @"
    SELECT COUNT(*) FROM users
    WHERE (@search IS NULL 
        OR ""Name"" ILIKE '%' || @search || '%' 
        OR ""Email"" ILIKE '%' || @search || '%')
    AND (@isActive IS NULL OR ""IsActive"" = @isActive)";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.Add(new NpgsqlParameter("search", NpgsqlTypes.NpgsqlDbType.Text)
            {
                Value = (object?)query.Search ?? DBNull.Value
            });

            cmd.Parameters.Add(new NpgsqlParameter("isActive", NpgsqlTypes.NpgsqlDbType.Boolean)
            {
                Value = (object?)query.IsActive ?? DBNull.Value
            });
            totalCount = Convert.ToInt32(await cmd.ExecuteScalarAsync());

            return (users, totalCount);
        }
    }
}