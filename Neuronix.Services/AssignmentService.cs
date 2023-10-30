using Neuronix.Core.IServices;
using Neuronix.Core.Models;

namespace Neuronix.Services;

public class AssignmentService : IAssignmentService
{
    public Task<IEnumerable<Assignment>> GetAllAssignments()
    {
        throw new NotImplementedException();
    }

    public Task<Assignment> GetAssignmentById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Assignment> CreateAssignment(Assignment newAssignment)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAssignment(Assignment assignmentToBeUpdated, Assignment assignment)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAssignment(Assignment assignment)
    {
        throw new NotImplementedException();
    }
}