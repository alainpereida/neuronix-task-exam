using Microsoft.EntityFrameworkCore;
using Neuronix.Core.IRepositories;
using Neuronix.Core.Models;

namespace Neuronix.Data.Repositories;

public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
{
    public AssignmentRepository(DbContext context) : base(context) { }
}