using aalaf.BAL.Dtos;
using aalaf.BAL.Interfaces;
using Api.Controllers.Base;
using Framework.Core.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers.Alaf
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BaseAPIController<IInvoiceService, Invoice, InvoiceDto>
    {

        public InvoiceController(IInvoiceService service,
            IUnitOfWork unitOfWork
            )
            : base(unitOfWork, service)
        {

        }

        [HttpGet("User")]
        public IActionResult GetInvioces()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok( _service.GetUserInvoices(userId));
        }



        [HttpGet("User/Cart")]
        public IActionResult GetCart()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok(_service.GetUserCart(userId));
        }


        [HttpPost("User/checkout")]
        public async Task<IActionResult> Checkout()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _service.Checkout(userId);
            return Ok();
        }


        [HttpPost("User/addtocart")]
        public async Task<IActionResult> AddToCart(Cart cart)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _service.AddToCart(cart.ProductId, cart.Quantity, cart.Total, userId);
            return Ok();
        }


    }

    public class Cart
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }

    }
}
