using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla_VillaAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        private string secretKey;
        public UserRepository(ApplicationDbContext db, IMapper mapper, IConfiguration configuration) {
            this.db = db;
            this.mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public bool IsUniqueUser(string username)
        {
            var user = db.LocalUsers.FirstOrDefault(
                x => x.Username == username);

            return user == null ? true : false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            var user = db.LocalUsers.FirstOrDefault(
                u => u.Username.ToLower() == loginRequest.Username.ToLower() &&  u.Password == loginRequest.Password);
            
            if(user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }

            // if user was found generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponse = new LoginResponseDTO
            {
                User = user,
                Token = tokenHandler.WriteToken(token)
            };
            return loginResponse;
        }

        public async Task<LocalUser> Register(RegistrationRequestDTO registrationRequest)
        {
            LocalUser user = mapper.Map<LocalUser>(registrationRequest);

            await db.LocalUsers.AddAsync(user);
            await db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
