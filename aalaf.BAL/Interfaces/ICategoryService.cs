using aalaf.BAL.Dtos;
using Framework.Core.UOW;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aalaf.BAL.Interfaces
{
    public interface ICategoryService : IBaseService<Category, CategoryVM>
    {
    }
}
