using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Neuronix.Core.IRepositories;
using Neuronix.Core.IServices;
using Neuronix.Core.Models;

namespace Neuronix.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _config;
    
    // <summary>
    /// AuthenticationService receive a IUnitOfWork Interface that encapsulates all Names of the All repositories
    /// that the Data Layer has for Data Base Operations. 
    /// </summary>
    /// <param name="unitOfWork">The Interface IUnitOfWork </param>
    /// <param name="config"></param>   
    public AuthenticationService(IUnitOfWork unitOfWork, IConfiguration config)
    {
        _unitOfWork = unitOfWork;
        _config = config;
    }
    
    /// <summary>
    /// Get the first or Default User Register filter by email
    /// </summary>
    public async Task<BaseResponse<AccessToken>> Login(string userName, string password)
    {
        //Declare variables for result and errors for be filled with the response of _unitOfWork
        BaseResponse<AccessToken> result = new BaseResponse<AccessToken>();
        List<string> err = new List<string>();

        try
        {
            //Search for user filtering by userName
            var user = await _unitOfWork.Users.FindUserByEmail(userName);
            
            if (user == null)
            {
                //If doesn't exist userName
                err.Add("El Usuario ingresado no existe ");
                result.errors = err;
                return result;
            }
            
            var token = (await GenerateJwtToken(user));

            result.DataResponse = token;
            result.Successful = true;
        }
        catch (Exception ex)
        {
            //If exist a Exception it's catched and Set in err List the Message 
            err.Add("Error en AuthenticationService -> Login " + ex.Message);
            //Set in the result errors object the exception message
            result.errors = err;
        }
        
        return result;
    }
    
    private async Task<AccessToken> GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim("NameUid", user.Id.ToString()),
            new Claim("Email", user.Email)
        };

        AuthenticationConfiguration authenticationConfiguration = new AuthenticationConfiguration
        {
            AccessTokenSecret = _config["Authentication:AccessTokenSecret"],
            AccessTokenExpirationDays = 30,
            Audience = _config["Authentication:Issuer"],
            Issuer = _config["Authentication:Audience"]
            
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfiguration.AccessTokenSecret));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        DateTime expirationTime = DateTime.UtcNow.AddDays(authenticationConfiguration.AccessTokenExpirationDays);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expirationTime,
            SigningCredentials = creds,
            Issuer = authenticationConfiguration.Issuer,
            Audience = authenticationConfiguration.Audience,
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new AccessToken
        {
            Token = tokenHandler.WriteToken(token),
            ExpirationTime = expirationTime
        };
    }
}