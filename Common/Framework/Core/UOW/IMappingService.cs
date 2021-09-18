using Framework.Core.Model;
using System.Collections.Generic;

namespace Framework.Core.UOW
{
    public interface IMappingService<T, TVM> where T : BaseEntity where TVM : IVM
    {
        T MapToEntity(TVM model);
        TVM MapToModel(T entity);
        IList<T> MapToEntity(IList<TVM> model);
        IList<TVM> MapToModel(IList<T> entity);
    }
}
