using FilterMutator.NetCore.Tests.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MutatorFX.FilterMutator;
using MutatorFX.FilterMutator.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilterMutator.NetCore.Tests
{
    [TestClass]
    public class DependencyInjectionTests
    {
        [TestMethod]
        public void CanResolveFilteringByGenericDependencies()
        {
            new ServiceCollection()
                .AddDbContext<TestDbContext>()
                .AddTransient<DbContext>(s => s.GetRequiredService<TestDbContext>())
                .AddSingleton(typeof(ISourceAccessor<>), typeof(DbSetSourceAccessor<>));
        }
    }
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddAlias<TAlias, T>(this IServiceCollection services)
            where TAlias : class
            where T : TAlias
            => services.AddTransient<TAlias>(s => s.GetRequiredService<T>());
    }
}
