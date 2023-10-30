using Neuronix.Core.Models;

namespace Neuronix.Core.IServices;

public interface IAssignmentService
{   
    Task<IEnumerable<Assignment>> GetAllAssignments();
    Task<Assignment> GetAssignmentById(int id);
    Task<Assignment> CreateAssignment(Assignment newAssignment);
    Task UpdateAssignment(Assignment assignmentToBeUpdated, Assignment assignment);
    Task DeleteAssignment(Assignment assignment);

}