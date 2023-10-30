using System.ComponentModel.DataAnnotations.Schema;

namespace Neuronix.Core.Models;

public abstract class BaseEntity
{ 
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}