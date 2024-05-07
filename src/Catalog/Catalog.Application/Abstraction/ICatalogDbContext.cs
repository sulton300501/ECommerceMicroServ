using Microsoft.EntityFrameworkCore;
using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Abstraction
{
    public interface ICatalogDbContext
    {
        public DbSet<ProductCatalog> Catalogs { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
