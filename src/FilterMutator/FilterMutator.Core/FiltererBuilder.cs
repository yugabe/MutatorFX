using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MutatorFX.FilterMutator
{
    public class FiltererBuilder<TFilter, TSource>
    {
        //private ICollection<IFilterClause<TFilter, TSource>> ClausesCollection { get; } = new List<IFilterClause<TFilter, TSource>>();
        //public IEnumerable<IFilterClause<TFilter, TSource>> Clauses => ClausesCollection;
        public FiltererBuilder() { }
        public static FiltererBuilder<TFilter, TSource> Create() => new FiltererBuilder<TFilter, TSource>();
        public static void T()
        {
            var filterer = FiltererBuilder<TestFilter, TestEntity>.Create()
                .WithClause(cb => cb.ForPropertyMatch(f => f.Id))
                .WithClause(cb => cb.ForPropertyChainMatch(f => f.ParentId))
                .WithClause(cb => cb.ForProperty(f => f.YoungestSiblingAge,
                    age => t => t.Parent.Children.Where(c => c.Id != t.Id).First(c => c.Age == age).Id))
                .Build();
        }
    }
    public class TestEntity
    {
        public int Id { get; set; }
        public TestEntity Parent { get; set; }
        public int Age { get; set; }
        public ICollection<TestEntity> Children { get; set; }
    }
    public class TestFilter
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int SiblingIdForAge { get; set; }
    }
    //public interface IFilterClause<in TFilter, TSource>
    //{
    //    object GetClause(TFilter filter);
    //    bool IsClauseEnabled(TFilter filter);
    //    Expression<Func<TSource, bool>> FilterPredicate { get; }
    //    Expression<Func<TSource, bool>> OnDisabledFilterPredicate { get; }
    //}

    public class FilterClause<TFilter, TSource, TClause>
    {
        public FilterClause(
            Expression<Func<TFilter, TClause>> filterClauseSelector,
            Func<TClause, Expression<Func<TSource, bool>>> filterPredicate,
            Expression<Func<TSource, bool>> onDisabledFilterPredicate = null,
            Func<TFilter, bool> isClauseEnabled = null)
        {
            FilterClauseSelector = filterClauseSelector;
            FilterPredicate = filterPredicate;
            OnDisabledFilterPredicate = onDisabledFilterPredicate;
            IsClauseEnabled = isClauseEnabled;
        }

        public Func<TFilter, bool> IsClauseEnabled { get; }
        public Expression<Func<TFilter, TClause>> FilterClauseSelector { get; }
        public Func<TClause, Expression<Func<TSource, bool>>> FilterPredicate { get; }
        public Expression<Func<TSource, bool>> OnDisabledFilterPredicate { get; }
    }
}
