
using BusinessLayer.Abstract;
using BusinessLayer.Model.DTOs.UserDTOs;
using BusinessLayer.Token;
using DataLayer.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AuthService :IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration; 
        public AuthService (IUserRepository userepository, IConfiguration configuration)
        {
            _userRepository = userepository;
            _configuration = configuration;
        }

        public AccessToken Login(UserLoginDto userLoginDto)
        {
            //user repositoryde where koşuluyla emailine göre kullanıcıyı getir.
            var user = _userRepository.GetUserWithPassword(userLoginDto.Email);
            if(user == null)
            {
                throw new Exception("UserNotFound");
            }
            //user repositoryden gelen parola girilen parola ile eşleşirse doğrudur 
            if (user.Password == userLoginDto.Password) {
                //amacımız bir jwt token oluşturmak jwt tokenin claiminde ise kullanıcıya ait bilgileri tutabiliriz
                //bundan dolayı claim yapısında kullanıcının rolü başta olmak üzere email ve name tutuyoruz.
                //expiredate ise kullanıcının kaç dakika pasif geçirdikten sonra sistemden atılacağını belirtir. Biz 15 dakika olarak belirledik.
                var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOption>();

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.Name),
                    new Claim(ClaimTypes.Role,user.UserRole.ToString()),
                    new Claim("PermissionCache",string.Concat(user.Name,user.Id))
                };
                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
               
                var jwtToken = new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                );

                var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                return new AccessToken() { 
                    Token = token, ExpireDate = DateTime.Now.AddMinutes(15), };
            }
            return new AccessToken() { };
        }
    }
}
