using Neuronix.Core.IRepositories;
using Neuronix.Core.IServices;
using Neuronix.Core.Models;

namespace Neuronix.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public AssignmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Assignment>> GetAllAssignments()
    {
        return await _unitOfWork.Assignments.GetAllAsync();
    }

    public async Task<Assignment> GetAssignmentById(int id)
    {
        return await _unitOfWork.Assignments.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Assignment>> GetAssignmentByUserId(int id)
    {
        return await _unitOfWork.Assignments.FindAssignmentsByUser(id);
    }

    public async Task<Assignment> CreateAssignment(Assignment newAssignment)
    {
        newAssignment.CreatedAt = DateTime.UtcNow;
        newAssignment.UpdatedAt = newAssignment.CreatedAt;
        
        await _unitOfWork.Assignments.AddAsync(newAssignment);
        await _unitOfWork.CommitAsync();
        return newAssignment;
    }

    public async Task UpdateAssignment(Assignment assignmentToBeUpdated, Assignment assignment)
    {
        assignmentToBeUpdated.Description = assignment.Description;
        assignmentToBeUpdated.IsCompleted = assignment.IsCompleted;
        assignmentToBeUpdated.UpdatedAt = DateTime.UtcNow;
        
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateAssignment(Assignment assignmentToBeUpdated, bool isCompleted)
    {
        assignmentToBeUpdated.IsCompleted = isCompleted;
        assignmentToBeUpdated.UpdatedAt = DateTime.UtcNow;
        
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteAssignment(Assignment assignment)
    {
        _unitOfWork.Assignments.Remove(assignment);
        await _unitOfWork.CommitAsync();
    }
}