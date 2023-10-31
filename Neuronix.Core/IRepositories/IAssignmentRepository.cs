using Neuronix.Core.Models;

namespace Neuronix.Core.IRepositories;

public interface IAssignmentRepository : IRepository<Assignment>
{
    Task<IEnumerable<Assignment>> FindAssignmentsByUser(int userId);
}