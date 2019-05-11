### QueryMutator

QueryMutator is a convention-based object mapper specifically built for Queryable projection. Easily create and customize mappings between objects, create mappings with runtime parameters or by using attributes. Mapping Queryables has never been easier!

### Quick start

First, create a configuration that contains your mappings:

```csharp
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMapping<Entity, EntityDto>(mapping => mapping
        .MapMember(dto => dto.DtoProperty, entity => entity.EntityProperty)
    );
});

// Use the built-in extension for DI registration
services.UseQueryMutator(config);

// Or create the mapper manually
var mapper = config.CreateMapper();
```
Then in your application code, retrieve and execute the mappings:

```csharp
var entityMapping = mapper.GetMapping<Entity, EntityDto>();
using (var context = new DatabaseContext())
{
    var dtos = context.Entities.Select(entityMapping).ToList();
}
```

### Overview

To create a mapping between two objects, use the CreateMapping method when configuring the mapper. If no arguments are passed, the mapping will be based on convention: all properties that are present in both object and have the same type will be mapped. With the help of the argument you can customize how each property can be mapped. (If a property is not customized, the mapping for that property will be based on convention.)

```csharp
// Convention-based
cfg.CreateMapping<Entity, EntityDto>();

// Customized
cfg.CreateMapping<Entity, EntityDto>(mapping => mapping
    .MapMember(dto => dto.DtoProperty, entity => entity.EntityProperty)
    .IgnoreMember(d => d.Ignored)
);
```
When mapping properties based on convention, if there exists a pair of properties (on the source and target object) that have the same name, but different type, then a new mapping will be automatically created (if it doesn't already exist) between the two types, based also on convention. This only works if both property types are classes, or implement IEnumerable<>. For example, when mapping Entity to EntityDto, a mapping will be also created between NestedEntity and NestedEntityDto:

```csharp
public class Entity
{
    public int Id { get; set; }
    public int? NestedEntityId { get; set; }
    public NestedEntity NestedEntity { get; set; }
}

public class EntityDto
{
    public int Id { get; set; }
    public NestedEntityDto NestedEntity { get; set; }
}
```

All mappings will be built when calling the CreateMapper method. After that, only the expressions are stored, which you can use in a Select method without any further actions. This makes sure there is no runtime overhead when projecting a data source.

### Customization options

- MapMember: Map the property to another property or constant. Also works with nullable types.
- IgnoreMember: Don't map the property.
- MapMemberList: Create a mapping between two IEnumerable<> properties.

### Property flattening

When creating a mapping, nested properties will be flattened based on naming convention. In this example the "ChildName" target property will be automatically mapped to the "Child.Name" source property.

```csharp
public class Entity
{
    public int Id { get; set; }
    public int ChildId { get; set; }    
    public Child Child { get; set; }
}

public class Child
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class EntityDto
{
    public int Id { get; set; }
    public string ChildName { get; set; }
}
```

### Attribute mapping

If you are looking for a more convenient but less customizable option, you can also try mapping with attributes. Just decorate your DTO classes with the MapFrom attribute and all properties will be mapped by convention. If you want to customize the source of a target property, you can do that by decorating it with the MapProperty attribute.

```csharp
[MapFrom(typeof(Entity))]
public class EntityDto
{
    public int Id { get; set; }
	
    [MapProperty(nameof(Entity.Name))]
    public string DtoName { get; set; }
}
```
Note: because in the newest language standard generic attributes are not yet supported, the MapProperty attribute finds the properties by name. This means there is no type safety in this case, so be careful.

Once the target classes are decorated, you have to tell QueryMutator which assemblies should be scanned for the classes. You can do this by calling the UseAttributeMapping method and passing the assemblies to it, when configuring the mapper.

```csharp
var config = new MapperConfiguration(cfg =>
{
    cfg.UseAttributeMapping(typeof(EntityDto).Assembly);
});
```

### Parameter mapping

It is also possible to create mappings that can take additional parameters when executing the mapping in your application. You can use these parameters in your property mappings to further customize them. Parameters can be primitives, but can also be classes.

```csharp
var config = new MapperConfiguration(cfg =>
{
    // Primitive parameter
    cfg.CreateMapping<Entity, EntityDto, int>(mapping => mapping
        .MapMemberWithParameter(dest => dest.Parameterized, param => source => source.Id * param)
    );
	
    // Object parameter
    cfg.CreateMapping<Entity, EntityDto, EntityParamaters>(mapping => mapping
        .MapMemberWithParameter(dest => dest.Parameterized, param => source => source.Id * param.IntProperty)
        .MapMemberWithParameter(dest => dest.Name, param => source => source.Name + param.StringProperty)
    );
});

// Usage

var mappingWithParameters = mapper.GetMapping<Entity, EntityDto, EntityParamaters>();

var @params = new EntityParamaters
{
    IntProperty = 10,
    StringProperty = "_concat"
};
var dtos = context.Entities.Select(mappingWithParameters, @params).ToList();
```
While normal mappings are built when configuring the mapper, parameter mappings have to be built when they are executed, so a slight overhead has to be expected in this case.

### Validation

If you want to make sure all properties are mapped, you can validate your mappings. Properties can be validate on both the source and the destination side. You can also set a global validation rule, or individually for each mapping.

```csharp
var config = new MapperConfiguration(cfg =>
{
    // Individual validation
    cfg.CreateMapping<Entity, EntityDto>(mapping => mapping
        .ValidateMapping(ValidationMode.Source)
    );
}, new MapperConfigurationOptions { ValidationMode = ValidationMode.Source }); // Global validation
```
