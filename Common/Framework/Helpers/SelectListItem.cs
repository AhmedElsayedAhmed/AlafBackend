using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Helpers
{
    public class SelectListItem
    {
        public string Key { get; set; }
        public IList<RequiredItems> Values { get; set; }
    }
}
