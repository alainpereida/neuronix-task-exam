using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neuronix.Core.Models;

namespace Neuronix.Data;

public class DataContext : DbContext
{
    public DbSet<User?> User { get; set; }
    public DbSet<Assignment> Assignment { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}