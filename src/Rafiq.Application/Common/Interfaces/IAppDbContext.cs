using Microsoft.EntityFrameworkCore;
using Rafiq.Domain.Test;

namespace Rafiq.Application.Common.Interfaces;
public interface IAppDbContext
{
    public DbSet<Test> Tests { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}