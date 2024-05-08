using Catalog.Application.Abstraction;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Domain;
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
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommands, ResponseModel>
    {
        private readonly ICatalogDbContext _catalogDbContext;

        public UpdateCatalogCommandHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        public async Task<ResponseModel> Handle(UpdateCatalogCommands request, CancellationToken cancellationToken)
        {

            var result = await _catalogDbContext.Catalogs.FirstOrDefaultAsync(x=>x.Id==request.Id);

            if (result != null)
            {

                result.Id = request.Id;
                result.Name = request.Name;
                result.Description = request.Description;
               

                _catalogDbContext.Catalogs.Update(result);
                await _catalogDbContext.SaveChangesAsync(cancellationToken);


                return new ResponseModel
                {
                    Message = "Succesfully Updated!",
                    StatusCode = 201
                };

            }

            
                return new ResponseModel
                {
                    StatusCode = 401,
                    Message = "The Catalog is not Updated"
                };
        


        }
    }
}
