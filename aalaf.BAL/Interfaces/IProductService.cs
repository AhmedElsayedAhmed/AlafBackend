using aalaf.BAL.Dtos;
using Framework.Core.UOW;
using Persistence;
using System.Collections.Generic;

namespace aalaf.BAL.Interfaces
{
    public interface IProductService : IBaseService<Product, ProductVM>
    {
        List<ProductVM> GetProductsByCategory(int categoryId);
    }
}
