using Framework.Core.BaseModel;
using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.UOW
{
    public interface IBaseService : IBaseService<BaseEntity, IVM>
    {
    }
}
