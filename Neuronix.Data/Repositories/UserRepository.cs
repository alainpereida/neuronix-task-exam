using Microsoft.EntityFrameworkCore;
using Neuronix.Core.IRepositories;
using Neuronix.Core.Models;

namespace Neuronix.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> FindUserByEmail(string email)
    {
        return await _context.User.FirstOrDefaultAsync(client => client != null && client.Email == email);
    }
}
    
