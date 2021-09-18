using aalaf.BAL.Dtos;
using Framework.Core.UOW;
using Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aalaf.BAL.Interfaces
{
    public interface IInvoiceService : IBaseService<Invoice, InvoiceDto>
    {
        IList<InvoiceDto> GetUserInvoices(int userId);
        InvoiceDto GetUserCart(int userId);
        Task Checkout(int userId);
        Task AddToCart(int productId, int quantity,int total, int userId);
    }
}
