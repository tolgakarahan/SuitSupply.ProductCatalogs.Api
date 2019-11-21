using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ISuitSupplyDbContext
    {
        DbSet<ProductCatalog> ProductCatalogs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
