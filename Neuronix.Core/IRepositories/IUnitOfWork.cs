namespace Neuronix.Core.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IAssignmentRepository Assignments { get; }

    Task<int> CommitAsync();
}
