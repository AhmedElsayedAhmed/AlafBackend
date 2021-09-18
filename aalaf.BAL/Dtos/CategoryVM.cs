using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aalaf.BAL.Dtos
{
    public class CategoryVM : IVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string ArTitle { get; set; }
        public string ArDescription { get; set; }
    }
}
