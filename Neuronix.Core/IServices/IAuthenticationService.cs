using Neuronix.Core.Models;

namespace Neuronix.Core.IServices;

public interface IAuthenticationService
{
    Task<BaseResponse<AccessToken>>  Login(String userName, String password);
}