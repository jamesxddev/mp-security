using Microsoft.EntityFrameworkCore;
using mp.security.Data;
using mp.security.Dtos.Auth;
using mp.security.Models;
using mp.security.Services.Interfaces;

namespace mp.security.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterAsync(RegisterRequest request)
        {
            var exist = await _context.Users
                .AnyAsync(x => x.Username == request.Username || x.Email == request.Email);

            if (exist)
            {
                return "User already exists";
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash
            };  

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return null;
        }

        public Task<string> LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
