using aalaf.BAL.Dtos;
using aalaf.BAL.Interfaces;
using AutoMapper;
using Framework.Core.BaseModel;
using Framework.Core.Repo;
using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.Extensions.Configuration;
using Persistence;
using Persistence.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace aalaf.BAL
{
    public class ProductService : BaseService<Product, ProductVM>, IProductService
    {
        private readonly IConfiguration _configuration;

        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork,
            aalafContext aalaf,
          IMapper mapper, IConfiguration configuration
            )
            : base(repository, unitOfWork, mapper)
        {

            _configuration = configuration;
        }

        public List<ProductVM> GetProductsByCategory(int categoryId)
        {
            var products = _unitOfWork.Products.Where(a => a.CategoryId == categoryId).ToList();
            var vm = MapentityListToModels(products).ToList();


            foreach (var item in vm)
            {
                var test = _unitOfWork.Medium.Where(a => a.ModelId == item.Id).FirstOrDefault();
                if (test != null && test.ModelType == "App\\Models\\Product")
                {
                    var mimType = test.MimeType == "image/jpeg" ? "jpg" : "png";
                    item.Photo = _configuration.GetSection("frontapp:url").Value + test.Id.ToString() + "/conversions/" + test.Name + "-thumb." + mimType;
                }
                    
            }
            return vm;
        }
    }
}
