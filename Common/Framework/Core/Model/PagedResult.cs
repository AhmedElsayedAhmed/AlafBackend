using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Model
{
    public class PagedResult<T, IVM> : IPagedResult<T, IVM> where T : class
    {
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Pages { get; set; }
        public IList<IVM> Result { get; set; }

        public PagedResult(IQueryable<T> queryable, int page, int size, Func<T, IVM> func)
        {
            TotalElements = queryable.Count();
            CurrentPage = page;
            PageSize = size;
            TotalPages = TotalElements / PageSize;

            if (TotalElements % PageSize > 0)
                TotalPages++;
            if (size > 0)
                Pages = (int)Math.Ceiling((decimal)TotalElements / (decimal)size);

            if (Pages == 0 && TotalElements > 0)
                Pages = 1;

            //if (Total > size)
                Result = queryable.Skip((page - 1) * size).Take(size).Select(func).ToList();
        }
    }
}