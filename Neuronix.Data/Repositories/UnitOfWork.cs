using Neuronix.Core.IRepositories;

namespace Neuronix.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    
    private AssignmentRepository _assignmentRepository;
    
    public UnitOfWork(DataContext context)
    {
        this._context = context;
    }

    public IAssignmentRepository Assignments => _assignmentRepository = _assignmentRepository ?? new AssignmentRepository(_context);
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}