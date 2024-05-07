using Catalog.Application.Abstraction;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handlers.CommandHandlers
{
    public class GetAllCatalogCommandHandler : IRequestHandler<GetAllCatalogCommands, ProductCatalog>
    {
        private readonly ICatalogDbContext _catalogDbContext;

        public GetAllCatalogCommandHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        public Task<List<ProductCatalog>> Handle(GetAllCatalogCommands request, CancellationToken cancellationToken)
        {
            var result = _catalogDbContext.Catalogs.ToListAsync();
            return result;
        }
    }
}
