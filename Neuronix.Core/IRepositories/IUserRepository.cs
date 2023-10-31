using Neuronix.Core.Models;

namespace Neuronix.Core.IRepositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> FindUserByEmail(string email);
}