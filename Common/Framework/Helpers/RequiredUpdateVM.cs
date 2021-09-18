using Framework.Core.Model;
using Framework.Helpers;
using System.Collections.Generic;

namespace Framework.Helpers
{
    public class RequiredUpdateVM<T> where T : IVM
    {
        public T Entity { get; set; }
        public IList<SelectListItem> SelectListItems { get; set; }
    }
}
