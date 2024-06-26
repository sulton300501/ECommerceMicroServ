﻿using Catalog.Application.Abstraction;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.CatalogControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediatr;


        public CatalogController(ICatalogDbContext context, IMediator mediatr)
        {
            _context = context;
            _mediatr = mediatr;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCatalog(CreateCatalogCommands command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
                 
                
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCatalog(DeleteCatalogCommands command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCatalog>>> GetAllCatalog()
        {
            var result = await _mediatr.Send(new GetAllCatalogCommands());
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCatalog(UpdateCatalogCommands command)
        {
            var result = await _mediatr.Send(command);
            return Ok(result);
        }



    }
}
