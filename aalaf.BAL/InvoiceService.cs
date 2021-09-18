using aalaf.BAL.Dtos;
using aalaf.BAL.Interfaces;
using AutoMapper;
using Framework.Core.BaseModel;
using Framework.Core.Repo;
using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aalaf.BAL
{
    public class InvoiceService : BaseService<Invoice, InvoiceDto>, IInvoiceService
    {
       
        public InvoiceService(IRepository<Invoice> repository, IUnitOfWork unitOfWork,
            aalafContext aalaf,
          IMapper mapper
            )
            : base(repository, unitOfWork, mapper)
        {


        }



        public IList<InvoiceDto> GetUserInvoices(int userId)
        {

            return MapentityListToModels(_repository.Table.Where(a => a.UserId == userId && a.Status != "cart").ToList());

           
        }


        public InvoiceDto GetUserCart(int userId)
        {
 

            return MapEntityToModel(_repository.Table.Include(a => a.Orders).ThenInclude(a => a.Product).Where(a => a.UserId == userId && a.Status == "cart").FirstOrDefault());


        }

        public async Task Checkout(int userId)
        {

            var order = _repository.Table.Where(a => a.UserId == userId && a.Status == "cart").FirstOrDefault();
            order.Status = "Pending";

            await _unitOfWork.Save();

        }

        public async Task AddToCart(int productId, int quantity, int totalPrice, int userId)
        {
           var invoice = _repository.Table.Include(a => a.Orders).ThenInclude(a => a.Product).Where(a => a.UserId == userId && a.Status == "cart").FirstOrDefault();
            var productPrice = _unitOfWork.Products.Where(a => a.Id == productId).FirstOrDefault()?.Price;
            if (invoice == null)
                _repository.Insert(new Invoice()
                {
                    CreatedAt = DateTime.Now,
                    UserId = userId,
                    Status = "cart",
                    Orders = new List<Order>()
                    {
                        new Order()
                        {
                            CreatedAt = DateTime.Now,
                            Quantity = quantity,
                            ProductId = productId,
                            Price =  productPrice* quantity
                        }
                    },
                    TotalPrice = productPrice * quantity


                });
            else
            {
                var product = invoice.Orders.Where(a => a.ProductId == productId).FirstOrDefault();
                if (product == null)
                    invoice.Orders.Add(new Order()
                    {
                        CreatedAt = DateTime.Now,
                        Quantity = quantity,
                        ProductId = productId,
                        Price = productPrice * quantity
                    });
                else
                {
                    product.Quantity += quantity;
                    product.Price = product.Price + productPrice * quantity;

                }

                invoice.TotalPrice += productPrice * quantity; 
            }


         


            await _unitOfWork.Save();
        }
    }
}
