using System;
using System.Collections.Generic;

namespace ASAN.Common
{
    public class PaginationViewModel<T> where T : class
    {
        public PaginationViewModel()
        {
            this.TotalRecord = 0;
            this.PageNo = 0;
            this.PageSize = 0;

            this.ModelItems = new List<T>();
        }

        public List<T> ModelItems { get; set; }

        public Int32 TotalRecord { get; set; }

        public Int32 PageNo { get; set; }

        public Int32 PageSize { get; set; }

        public String ConditionPhrase { get; set; }
    }
}
