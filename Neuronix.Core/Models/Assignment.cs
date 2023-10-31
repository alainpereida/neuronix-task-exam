using System.ComponentModel;

namespace Neuronix.Core.Models;

public class Assignment : BaseEntity
{
    public int Id { get; set; }
    
    public string Description { get; set; }
    
    [DefaultValue("false")]
    public bool IsCompleted { get; set; }
    
    public int UserId { get; set; }
    public virtual User User { get; set; }
}