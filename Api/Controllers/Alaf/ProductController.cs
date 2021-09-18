using aalaf.BAL.Dtos;
using aalaf.BAL.Interfaces;
using Api.Controllers.Base;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Collections.Generic;

namespace Api.Controllers.Alaf
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseAPIController<IProductService, Product, ProductVM>
    {

        public ProductController(IProductService service,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, service)
        {
           
        }

        [HttpGet("category/{categoryId}")]
        public List<ProductVM> GetProductsByCategory(int categoryId)
        {
            return _service.GetProductsByCategory(categoryId);
        }
    }
}
