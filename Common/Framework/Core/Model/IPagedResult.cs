using System.Collections.Generic;

namespace Framework.Core.Model
{
    public interface IPagedResult<T, IVM> where T : class
    {
        int TotalElements { get; set; }
        int TotalPages { get; set; }
        int CurrentPage { get; set; }
        int PageSize { get; set; }
        int Pages { get; set; }
        IList<IVM> Result { get; set; }
    }
}
