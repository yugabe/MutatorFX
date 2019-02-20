using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MutatorFX.QueryMutator;
using MutatorFX.QueryMutator.Linq;

namespace QueryMutator.Tests
{
    public class Program
    {
        public static readonly ILoggerFactory ConsoleLoggerFactory
            = new ServiceCollection()
                .AddLogging(builder => builder
                    .AddConsole()
                    .AddFilter(level => level >= LogLevel.Information))
                .BuildServiceProvider()
                .GetService<ILoggerFactory>();

        public static void Main(string[] args)
        {
            //var dogToDtoMapping = Mapping<Dog, DogDto, string>.Create(mapping => mapping
            //    .MapMember(k => k.Name, p => k => k.Name + p)
            //    .MapMatchingPropertyChains()
            //    //.MapMember(k => k.DtoProperty, kk => kk.EntityProperty)
            //    .IgnoreMember(k => k.Ignored)
            //    );

            var dogToDtoMapping = Mapping<Dog, DogDto>.Create(mapping => mapping
                .MapMember(k => k.Id, kk => kk.Id)
                .MapMember(k => k.SmallDog, kk => new SmallDogDto { Id = kk.SmallDog.Id, Name = kk.SmallDog.Name })
                //.MapMatchingPropertyChains()
                //.MapMember(k => k.Name, kk => kk.Name)
                .MapMember(k => k.DtoProperty, kk => kk.EntityProperty)
                .IgnoreMember(k => k.Ignored)
                );

            using (var context = new DatabaseContext())
            {
                var dog = context.Dogs.Where(d => d.Id == 1).FirstOrDefault();
                
                var dogs = context.Dogs.Select(dogToDtoMapping).ToList();

                Console.WriteLine(dog);
            }

            Console.ReadKey();
        }
    }
}
