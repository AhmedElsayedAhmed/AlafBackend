using aalaf.BAL.Dtos;
using aalaf.BAL.Interfaces;
using AutoMapper;
using Framework.Core.BaseModel;
using Framework.Core.Repo;
using Framework.Core.UOW;
using Framework.Helpers;
using Persistence;
using Persistence.UnitOfWork;

namespace aalaf.BAL
{
    public class CategoryService : BaseService<Category, CategoryVM>, ICategoryService
    {
        private aalafContext _aalaf;
        public CategoryService(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork,
            aalafContext aalaf,
          IMapper mapper
            )
            : base(categoryRepository, unitOfWork, mapper)
        {
            _aalaf = aalaf;

            
    }


        //public override Category Insert(CategoryVM model)
        //{
        //    Category entity = MapModelToEntity(model);

        //    var un = new UnitOfWork(_aalaf);
        //    un.Category.Insert(entity);
        //    _aalaf.Categories.Add(entity);
        //    _aalaf.SaveChanges();
          
        //    return entity;
        //}
    }
}
