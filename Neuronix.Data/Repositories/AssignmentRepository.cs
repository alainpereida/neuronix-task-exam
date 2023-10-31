using Microsoft.EntityFrameworkCore;
using Neuronix.Core.IRepositories;
using Neuronix.Core.Models;

namespace Neuronix.Data.Repositories;

public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
{
    private readonly DataContext _context;
    public AssignmentRepository(DataContext context) : base(context) 
    {
        _context = context; 
    }
    
    public async Task<IEnumerable<Assignment>> FindAssignmentsByUser(int userId)
    {
        return await _context.Assignment
            .OrderByDescending(a => a.CreatedAt)
            .Where(a => a.UserId == userId)
            .ToListAsync();
    }
}