using aalaf.BAL.Dtos;
using aalaf.BAL.Interfaces;
using Api.Controllers.Base;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Api.Controllers.Alaf
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseAPIController<ICategoryService, Category, CategoryVM>
    {

        public CategoryController(ICategoryService service,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, service)
        {
           
        }
    }
}
