using System;

namespace MutatorFX.FilterMutator
{
    public class PagedQuery<TFilter, TSort>
        where TSort : Enum
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public TFilter Filter { get; set; }
        public TSort Sorting { get; set; }
        public bool SortDescending { get; set; }
    }
}
