using System.Collections.Generic;

namespace Framework.Core.Model
{
    public class QueryModel
    {
        public QueryModel()
        {
            CurrentPage = 1;
            PageSize = 10;
            Sort = "Id";
            SortDirection = "des";
            SearchTerm = string.Empty;
            Long = 0;
            Lat = 0;
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public string SortDirection { get; set; }
        public string SearchTerm { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
    }
}