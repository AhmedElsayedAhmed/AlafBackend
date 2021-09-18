using Framework.Core.Model;
using System.Collections.Generic;

namespace Framework.Basic
{
    public class SaveResult
    {
        public int Affected { get; set; }

        public IList<Error> Errors{ get; set; }

        public SaveResult()
        {
            Errors = new List<Error>();
        }
    }
}