using System;
using System.Linq;
using System.Linq.Expressions;

namespace QueryMutator.Core
{

    public interface IMapper
    {
        IMapping<TSource, TTarget> GetMapping<TSource, TTarget>();

        IMapping<TSource, TTarget, TParam> GetMapping<TSource, TTarget, TParam>();
    }

    public interface IMapping<TSource, TTarget>
    {
    }

    public interface IMapping<TSource, TTarget, TParam>
    {
    }

    public interface IMappingBuilder<TSource, TTarget>
    {
        IMappingBuilder<TSource, TTarget> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression);

        IMappingBuilder<TSource, TTarget> MapMemberUsing<TMember, TMapSource>(Expression<Func<TTarget, TMember>> memberSelector, IMapping<TMapSource, TMember> mapping);

        IMappingBuilder<TSource, TTarget> IgnoreMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector);
    }

    public interface IMappingBuilder<TSource, TTarget, TParam>
    {
        IMappingBuilder<TSource, TTarget, TParam> MapMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Expression<Func<TSource, TMember>> mappingExpression);

        IMappingBuilder<TSource, TTarget, TParam> MapMemberUsing<TMember, TMapSource>(Expression<Func<TTarget, TMember>> memberSelector, IMapping<TMapSource, TMember> mapping);

        IMappingBuilder<TSource, TTarget, TParam> MapMemberWithParameter<TMember>(Expression<Func<TTarget, TMember>> memberSelector, Func<TParam, Expression<Func<TSource, TMember>>> mappingExpression);

        IMappingBuilder<TSource, TTarget, TParam> IgnoreMember<TMember>(Expression<Func<TTarget, TMember>> memberSelector);
    }

    public interface IMapperConfigurationExpression
    {
        IMapping<TSource, TTarget> CreateMapping<TSource, TTarget>();

        IMapping<TSource, TTarget> CreateMapping<TSource, TTarget>(Action<IMappingBuilder<TSource, TTarget>> mappingFactory);

        IMapping<TSource, TTarget, TParam> CreateMapping<TSource, TTarget, TParam>(Action<IMappingBuilder<TSource, TTarget, TParam>> mappingFactory);
    }

    public class MapperConfiguration
    {
        public MapperConfiguration(Action<IMapperConfigurationExpression> expression)
        {
            throw new NotImplementedException();
        }

        public IMapper CreateMapper()
        {
            throw new NotImplementedException();
        }
    }

    public static class QueryableExtensions
    {
        public static IQueryable<T> Select<TSource, T>(this IQueryable source, IMapping<TSource, T> mapping)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<T> Select<TSource, T>(this IQueryable<TSource> source, IMapping<TSource, T> mapping)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<T> Select<TSource, T, TParameter>(this IQueryable source, IMapping<TSource, T, TParameter> mapping, TParameter parameter)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<T> Select<TSource, T, TParameter>(this IQueryable<TSource> source, IMapping<TSource, T, TParameter> mapping, TParameter parameter)
        {
            throw new NotImplementedException();
        }

    }
}
