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
    public class OrderController : BaseAPIController<IOrderService, Order, OrderDto>
    {

        public OrderController(IOrderService service,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, service)
        {
           
        }

       
    }
}
