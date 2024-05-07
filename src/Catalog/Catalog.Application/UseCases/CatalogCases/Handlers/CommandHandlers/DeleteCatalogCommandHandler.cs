using Catalog.Application.Abstraction;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handlers.CommandHandlers
{
    public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommands, ResponseModel>
    {
        private readonly ICatalogDbContext _catalogDbContext;

        public DeleteCatalogCommandHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteCatalogCommands request, CancellationToken cancellationToken)
        {
           var result = await _catalogDbContext.Catalogs.FirstOrDefaultAsync(x=>x.Id == request.Id);
            
            if(result != null)
            {
                _catalogDbContext.Catalogs.Remove(result);
                await _catalogDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    IsSuccess = true,
                    Message = "Succes deleted"
                };
            }


            return new ResponseModel
            {
                StatusCode = 401,
                Message = "The News Is not Found"
            };


        }

    }
}
