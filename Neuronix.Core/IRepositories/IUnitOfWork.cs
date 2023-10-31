namespace Neuronix.Core.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IAssignmentRepository Assignments { get; }

    IUserRepository Users { get; }
    
    Task<int> CommitAsync();
}
