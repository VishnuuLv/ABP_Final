using BCryptNet = BCrypt.Net.BCrypt;
using Flight.Services.UserManagement.Authorization;
using Flight.Services.UserManagement.Entities;
using Flight.Services.UserManagement.Helpers;
using Flight.Services.UserManagement.Models.Users;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Flight.Services.UserManagement.Services
{

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        Task<UserDto> CreateUser(UserDto userDto);
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;
        private readonly DataContext _db;
        private IMapper _mapper;

        public UserService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings, DataContext db, IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
            _db = db;
            _mapper = mapper;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);
            var jwtToken="";

            // validate // authentication successful so generate jwt token
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                user = new User();
                user.Id = 0;
                user.FirstName = "";
                user.LastName = "";
                user.Role = 0;
                user.Username = "";
                return new AuthenticateResponse(user, jwtToken);
            }
            else
            {
                jwtToken = _jwtUtils.GenerateJwtToken(user);
            }

            return new AuthenticateResponse(user, jwtToken);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            User user = _mapper.Map<UserDto, User>(userDto);

            user.PasswordHash = BCryptNet.HashPassword(userDto.PasswordHash);
            
                _db.Users.Add(user);
            
            await _db.SaveChangesAsync();

            return _mapper.Map<User, UserDto>(user);
        }
    }

}
