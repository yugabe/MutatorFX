<a name='assembly'></a>
# MutatorFX.QueryMutator.Core

## Contents

- [IMapper](#T-QueryMutator-Core-IMapper 'QueryMutator.Core.IMapper')
  - [GetMapping\`\`2()](#M-QueryMutator-Core-IMapper-GetMapping``2 'QueryMutator.Core.IMapper.GetMapping``2')
  - [GetMapping\`\`3()](#M-QueryMutator-Core-IMapper-GetMapping``3 'QueryMutator.Core.IMapper.GetMapping``3')
- [IMapperConfigurationExpression](#T-QueryMutator-Core-IMapperConfigurationExpression 'QueryMutator.Core.IMapperConfigurationExpression')
  - [CreateMapping\`\`2()](#M-QueryMutator-Core-IMapperConfigurationExpression-CreateMapping``2 'QueryMutator.Core.IMapperConfigurationExpression.CreateMapping``2')
  - [CreateMapping\`\`2()](#M-QueryMutator-Core-IMapperConfigurationExpression-CreateMapping``2-System-Action{QueryMutator-Core-IMappingBuilder{``0,``1}}- 'QueryMutator.Core.IMapperConfigurationExpression.CreateMapping``2(System.Action{QueryMutator.Core.IMappingBuilder{``0,``1}})')
  - [CreateMapping\`\`3()](#M-QueryMutator-Core-IMapperConfigurationExpression-CreateMapping``3-System-Action{QueryMutator-Core-IMappingBuilder{``0,``1,``2}}- 'QueryMutator.Core.IMapperConfigurationExpression.CreateMapping``3(System.Action{QueryMutator.Core.IMappingBuilder{``0,``1,``2}})')
  - [UseAttributeMapping(assemblies)](#M-QueryMutator-Core-IMapperConfigurationExpression-UseAttributeMapping-System-Reflection-Assembly[]- 'QueryMutator.Core.IMapperConfigurationExpression.UseAttributeMapping(System.Reflection.Assembly[])')
- [IMapping](#T-QueryMutator-Core-IMapping 'QueryMutator.Core.IMapping')
  - [Expression](#P-QueryMutator-Core-IMapping-Expression 'QueryMutator.Core.IMapping.Expression')
- [IMapping\`2](#T-QueryMutator-Core-IMapping`2 'QueryMutator.Core.IMapping`2')
  - [Expression](#P-QueryMutator-Core-IMapping`2-Expression 'QueryMutator.Core.IMapping`2.Expression')
- [IMapping\`3](#T-QueryMutator-Core-IMapping`3 'QueryMutator.Core.IMapping`3')
- [IMappingBuilder\`2](#T-QueryMutator-Core-IMappingBuilder`2 'QueryMutator.Core.IMappingBuilder`2')
  - [IgnoreMember\`\`1(memberSelector)](#M-QueryMutator-Core-IMappingBuilder`2-IgnoreMember``1-System-Linq-Expressions-Expression{System-Func{`1,``0}}- 'QueryMutator.Core.IMappingBuilder`2.IgnoreMember``1(System.Linq.Expressions.Expression{System.Func{`1,``0}})')
  - [MapMember\`\`1(memberSelector,constant)](#M-QueryMutator-Core-IMappingBuilder`2-MapMember``1-System-Linq-Expressions-Expression{System-Func{`1,``0}},``0- 'QueryMutator.Core.IMappingBuilder`2.MapMember``1(System.Linq.Expressions.Expression{System.Func{`1,``0}},``0)')
  - [MapMember\`\`1(memberSelector,mappingExpression)](#M-QueryMutator-Core-IMappingBuilder`2-MapMember``1-System-Linq-Expressions-Expression{System-Func{`1,``0}},System-Linq-Expressions-Expression{System-Func{`0,``0}}- 'QueryMutator.Core.IMappingBuilder`2.MapMember``1(System.Linq.Expressions.Expression{System.Func{`1,``0}},System.Linq.Expressions.Expression{System.Func{`0,``0}})')
  - [MapMember\`\`1(memberSelector,mappingExpression)](#M-QueryMutator-Core-IMappingBuilder`2-MapMember``1-System-Linq-Expressions-Expression{System-Func{`1,``0}},System-Linq-Expressions-Expression{System-Func{`0,System-Nullable{``0}}}- 'QueryMutator.Core.IMappingBuilder`2.MapMember``1(System.Linq.Expressions.Expression{System.Func{`1,``0}},System.Linq.Expressions.Expression{System.Func{`0,System.Nullable{``0}}})')
  - [MapMember\`\`1(memberSelector,mappingExpression)](#M-QueryMutator-Core-IMappingBuilder`2-MapMember``1-System-Linq-Expressions-Expression{System-Func{`1,System-Nullable{``0}}},System-Linq-Expressions-Expression{System-Func{`0,``0}}- 'QueryMutator.Core.IMappingBuilder`2.MapMember``1(System.Linq.Expressions.Expression{System.Func{`1,System.Nullable{``0}}},System.Linq.Expressions.Expression{System.Func{`0,``0}})')
  - [MapMemberList\`\`2(memberSelector,mappingExpression)](#M-QueryMutator-Core-IMappingBuilder`2-MapMemberList``2-System-Linq-Expressions-Expression{System-Func{`1,System-Collections-Generic-IEnumerable{``0}}},System-Linq-Expressions-Expression{System-Func{`0,System-Collections-Generic-IEnumerable{``1}}}- 'QueryMutator.Core.IMappingBuilder`2.MapMemberList``2(System.Linq.Expressions.Expression{System.Func{`1,System.Collections.Generic.IEnumerable{``0}}},System.Linq.Expressions.Expression{System.Func{`0,System.Collections.Generic.IEnumerable{``1}}})')
  - [ValidateMapping(mode)](#M-QueryMutator-Core-IMappingBuilder`2-ValidateMapping-QueryMutator-Core-ValidationMode- 'QueryMutator.Core.IMappingBuilder`2.ValidateMapping(QueryMutator.Core.ValidationMode)')
- [IMappingBuilder\`3](#T-QueryMutator-Core-IMappingBuilder`3 'QueryMutator.Core.IMappingBuilder`3')
  - [MapMemberWithParameter\`\`1(memberSelector,mappingExpression)](#M-QueryMutator-Core-IMappingBuilder`3-MapMemberWithParameter``1-System-Linq-Expressions-Expression{System-Func{`1,``0}},System-Func{`2,System-Linq-Expressions-Expression{System-Func{`0,``0}}}- 'QueryMutator.Core.IMappingBuilder`3.MapMemberWithParameter``1(System.Linq.Expressions.Expression{System.Func{`1,``0}},System.Func{`2,System.Linq.Expressions.Expression{System.Func{`0,``0}}})')
- [InvalidPropertyNameException](#T-QueryMutator-Core-InvalidPropertyNameException 'QueryMutator.Core.InvalidPropertyNameException')
- [MapFromAttribute](#T-QueryMutator-Core-MapFromAttribute 'QueryMutator.Core.MapFromAttribute')
  - [#ctor(sourceType)](#M-QueryMutator-Core-MapFromAttribute-#ctor-System-Type- 'QueryMutator.Core.MapFromAttribute.#ctor(System.Type)')
  - [SourceType](#P-QueryMutator-Core-MapFromAttribute-SourceType 'QueryMutator.Core.MapFromAttribute.SourceType')
- [MapperConfiguration](#T-QueryMutator-Core-MapperConfiguration 'QueryMutator.Core.MapperConfiguration')
  - [#ctor(expression,options)](#M-QueryMutator-Core-MapperConfiguration-#ctor-System-Action{QueryMutator-Core-IMapperConfigurationExpression},QueryMutator-Core-MapperConfigurationOptions- 'QueryMutator.Core.MapperConfiguration.#ctor(System.Action{QueryMutator.Core.IMapperConfigurationExpression},QueryMutator.Core.MapperConfigurationOptions)')
  - [CreateMapper()](#M-QueryMutator-Core-MapperConfiguration-CreateMapper 'QueryMutator.Core.MapperConfiguration.CreateMapper')
- [MapperConfigurationOptions](#T-QueryMutator-Core-MapperConfigurationOptions 'QueryMutator.Core.MapperConfigurationOptions')
  - [ValidationMode](#P-QueryMutator-Core-MapperConfigurationOptions-ValidationMode 'QueryMutator.Core.MapperConfigurationOptions.ValidationMode')
- [MappingAlreadyExistsException](#T-QueryMutator-Core-MappingAlreadyExistsException 'QueryMutator.Core.MappingAlreadyExistsException')
- [MappingNotFoundException](#T-QueryMutator-Core-MappingNotFoundException 'QueryMutator.Core.MappingNotFoundException')
- [MappingValidationException](#T-QueryMutator-Core-MappingValidationException 'QueryMutator.Core.MappingValidationException')
- [MapPropertyAttribute](#T-QueryMutator-Core-MapPropertyAttribute 'QueryMutator.Core.MapPropertyAttribute')
  - [#ctor(propertyName)](#M-QueryMutator-Core-MapPropertyAttribute-#ctor-System-String- 'QueryMutator.Core.MapPropertyAttribute.#ctor(System.String)')
  - [PropertyName](#P-QueryMutator-Core-MapPropertyAttribute-PropertyName 'QueryMutator.Core.MapPropertyAttribute.PropertyName')
- [QueryableExtensions](#T-QueryMutator-Core-QueryableExtensions 'QueryMutator.Core.QueryableExtensions')
  - [Select\`\`2(source,mapping)](#M-QueryMutator-Core-QueryableExtensions-Select``2-System-Linq-IQueryable{``0},QueryMutator-Core-IMapping{``0,``1}- 'QueryMutator.Core.QueryableExtensions.Select``2(System.Linq.IQueryable{``0},QueryMutator.Core.IMapping{``0,``1})')
  - [Select\`\`3(source,mapping,parameter)](#M-QueryMutator-Core-QueryableExtensions-Select``3-System-Linq-IQueryable{``0},QueryMutator-Core-IMapping{``0,``1,``2},``2- 'QueryMutator.Core.QueryableExtensions.Select``3(System.Linq.IQueryable{``0},QueryMutator.Core.IMapping{``0,``1,``2},``2)')
- [QueryMutatorExtensions](#T-QueryMutator-Core-QueryMutatorExtensions 'QueryMutator.Core.QueryMutatorExtensions')
  - [UseQueryMutator(config,registerIndividualMappings)](#M-QueryMutator-Core-QueryMutatorExtensions-UseQueryMutator-Microsoft-Extensions-DependencyInjection-IServiceCollection,QueryMutator-Core-MapperConfiguration,System-Boolean- 'QueryMutator.Core.QueryMutatorExtensions.UseQueryMutator(Microsoft.Extensions.DependencyInjection.IServiceCollection,QueryMutator.Core.MapperConfiguration,System.Boolean)')
- [ValidationMode](#T-QueryMutator-Core-ValidationMode 'QueryMutator.Core.ValidationMode')
  - [Destination](#F-QueryMutator-Core-ValidationMode-Destination 'QueryMutator.Core.ValidationMode.Destination')
  - [None](#F-QueryMutator-Core-ValidationMode-None 'QueryMutator.Core.ValidationMode.None')
  - [Source](#F-QueryMutator-Core-ValidationMode-Source 'QueryMutator.Core.ValidationMode.Source')

<a name='T-QueryMutator-Core-IMapper'></a>
## IMapper `type`

##### Namespace

QueryMutator.Core

##### Summary

Represents an object that contains mappings.

<a name='M-QueryMutator-Core-IMapper-GetMapping``2'></a>
### GetMapping\`\`2() `method`

##### Summary

Return a mapping specified by the `TSource`and `TTarget`types.

##### Returns

The specified mapping.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type of the mapping. |
| TTarget | The target type of the mapping. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [QueryMutator.Core.MappingNotFoundException](#T-QueryMutator-Core-MappingNotFoundException 'QueryMutator.Core.MappingNotFoundException') | Thrown when the mapping is not found. |

<a name='M-QueryMutator-Core-IMapper-GetMapping``3'></a>
### GetMapping\`\`3() `method`

##### Summary

Return a mapping specified by the `TSource`, `TTarget`and `TParam`types.

##### Returns

The specified mapping.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type of the mapping. |
| TTarget | The target type of the mapping. |
| TParam | The parameter type of the mapping. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [QueryMutator.Core.MappingNotFoundException](#T-QueryMutator-Core-MappingNotFoundException 'QueryMutator.Core.MappingNotFoundException') | Thrown when the mapping is not found. |

<a name='T-QueryMutator-Core-IMapperConfigurationExpression'></a>
## IMapperConfigurationExpression `type`

##### Namespace

QueryMutator.Core

##### Summary

Represents an object which can be used to define mappings.

<a name='M-QueryMutator-Core-IMapperConfigurationExpression-CreateMapping``2'></a>
### CreateMapping\`\`2() `method`

##### Summary

Creates a new default mapping between the `TSource`and `TTarget`types.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type of the mapping. |
| TTarget | The target type of the mapping. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [QueryMutator.Core.MappingAlreadyExistsException](#T-QueryMutator-Core-MappingAlreadyExistsException 'QueryMutator.Core.MappingAlreadyExistsException') | Thrown when another mapping with the same generic parameters already exists. |

<a name='M-QueryMutator-Core-IMapperConfigurationExpression-CreateMapping``2-System-Action{QueryMutator-Core-IMappingBuilder{``0,``1}}-'></a>
### CreateMapping\`\`2() `method`

##### Summary

Creates a new mapping between the `TSource`and `TTarget`types,
using the supplied `mappingFactory`options.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type of the mapping. |
| TTarget | The target type of the mapping. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [QueryMutator.Core.MappingAlreadyExistsException](#T-QueryMutator-Core-MappingAlreadyExistsException 'QueryMutator.Core.MappingAlreadyExistsException') | Thrown when another mapping with the same generic parameters already exists. |

<a name='M-QueryMutator-Core-IMapperConfigurationExpression-CreateMapping``3-System-Action{QueryMutator-Core-IMappingBuilder{``0,``1,``2}}-'></a>
### CreateMapping\`\`3() `method`

##### Summary

Creates a new mapping between the `TSource`, `TTarget`and `TParam`types,
using the supplied `mappingFactory`options.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type of the mapping. |
| TTarget | The target type of the mapping. |
| TParam | The parameter type of the mapping. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [QueryMutator.Core.MappingAlreadyExistsException](#T-QueryMutator-Core-MappingAlreadyExistsException 'QueryMutator.Core.MappingAlreadyExistsException') | Thrown when another mapping with the same generic parameters already exists. |

<a name='M-QueryMutator-Core-IMapperConfigurationExpression-UseAttributeMapping-System-Reflection-Assembly[]-'></a>
### UseAttributeMapping(assemblies) `method`

##### Summary

Enable scanning the supplied `assemblies`for objects decorated with the [MapFromAttribute](#T-QueryMutator-Core-MapFromAttribute 'QueryMutator.Core.MapFromAttribute')attribute.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assemblies | [System.Reflection.Assembly[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.Assembly[] 'System.Reflection.Assembly[]') | The assemblies to be scanned. |

<a name='T-QueryMutator-Core-IMapping'></a>
## IMapping `type`

##### Namespace

QueryMutator.Core

##### Summary

Represents a generic mapping.

<a name='P-QueryMutator-Core-IMapping-Expression'></a>
### Expression `property`

##### Summary

Contains the expression used for the mapping.

<a name='T-QueryMutator-Core-IMapping`2'></a>
## IMapping\`2 `type`

##### Namespace

QueryMutator.Core

##### Summary

Represents a mapping.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type of the mapping. |
| TTarget | The target type of the mapping. |

<a name='P-QueryMutator-Core-IMapping`2-Expression'></a>
### Expression `property`

##### Summary

Contains the expression used for the mapping.

<a name='T-QueryMutator-Core-IMapping`3'></a>
## IMapping\`3 `type`

##### Namespace

QueryMutator.Core

##### Summary

Represents a mapping with a parameter.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type of the mapping. |
| TTarget | The target type of the mapping. |
| TParam | The parameter type of the mapping. |

<a name='T-QueryMutator-Core-IMappingBuilder`2'></a>
## IMappingBuilder\`2 `type`

##### Namespace

QueryMutator.Core

##### Summary

Represents an object that can be used to create a custom mapping between the 
`TSource`and `TTarget`types.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type of the mapping. |
| TTarget | The target type of the mapping. |

<a name='M-QueryMutator-Core-IMappingBuilder`2-IgnoreMember``1-System-Linq-Expressions-Expression{System-Func{`1,``0}}-'></a>
### IgnoreMember\`\`1(memberSelector) `method`

##### Summary

Ignores the selected target property, excluding it from the mapping.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberSelector | [System.Linq.Expressions.Expression{System.Func{\`1,\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`1,``0}}') | The selector for the target property. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TMember | The type of the property. |

<a name='M-QueryMutator-Core-IMappingBuilder`2-MapMember``1-System-Linq-Expressions-Expression{System-Func{`1,``0}},``0-'></a>
### MapMember\`\`1(memberSelector,constant) `method`

##### Summary

Creates a mapping between a target property and a constant.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberSelector | [System.Linq.Expressions.Expression{System.Func{\`1,\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`1,``0}}') | The selector for the target property. |
| constant | [\`\`0](#T-``0 '``0') | The value of the constant. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TMember | The type of the property. |

<a name='M-QueryMutator-Core-IMappingBuilder`2-MapMember``1-System-Linq-Expressions-Expression{System-Func{`1,``0}},System-Linq-Expressions-Expression{System-Func{`0,``0}}-'></a>
### MapMember\`\`1(memberSelector,mappingExpression) `method`

##### Summary

Creates a mapping between a target and a source property.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberSelector | [System.Linq.Expressions.Expression{System.Func{\`1,\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`1,``0}}') | The selector for the target property. |
| mappingExpression | [System.Linq.Expressions.Expression{System.Func{\`0,\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,``0}}') | The expression for the source property. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TMember | The type of the property. |

<a name='M-QueryMutator-Core-IMappingBuilder`2-MapMember``1-System-Linq-Expressions-Expression{System-Func{`1,``0}},System-Linq-Expressions-Expression{System-Func{`0,System-Nullable{``0}}}-'></a>
### MapMember\`\`1(memberSelector,mappingExpression) `method`

##### Summary

Creates a mapping between a target and a source property, where the source property type is nullable.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberSelector | [System.Linq.Expressions.Expression{System.Func{\`1,\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`1,``0}}') | The selector for the target property. |
| mappingExpression | [System.Linq.Expressions.Expression{System.Func{\`0,System.Nullable{\`\`0}}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Nullable{``0}}}') | The expression for the source property. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TMember | The underlying property type. |

<a name='M-QueryMutator-Core-IMappingBuilder`2-MapMember``1-System-Linq-Expressions-Expression{System-Func{`1,System-Nullable{``0}}},System-Linq-Expressions-Expression{System-Func{`0,``0}}-'></a>
### MapMember\`\`1(memberSelector,mappingExpression) `method`

##### Summary

Creates a mapping between a target and a source property, where the target property type is nullable.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberSelector | [System.Linq.Expressions.Expression{System.Func{\`1,System.Nullable{\`\`0}}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`1,System.Nullable{``0}}}') | The selector for the target property. |
| mappingExpression | [System.Linq.Expressions.Expression{System.Func{\`0,\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,``0}}') | The expression for the source property. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TMember | The underlying property type. |

<a name='M-QueryMutator-Core-IMappingBuilder`2-MapMemberList``2-System-Linq-Expressions-Expression{System-Func{`1,System-Collections-Generic-IEnumerable{``0}}},System-Linq-Expressions-Expression{System-Func{`0,System-Collections-Generic-IEnumerable{``1}}}-'></a>
### MapMemberList\`\`2(memberSelector,mappingExpression) `method`

##### Summary

Creates a mapping between a target and a source property, where each property type implements [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1').
If no mapping exists between `TSourceMember`and `TTargetMember`, a default mapping will be created.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberSelector | [System.Linq.Expressions.Expression{System.Func{\`1,System.Collections.Generic.IEnumerable{\`\`0}}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`1,System.Collections.Generic.IEnumerable{``0}}}') | The selector for the target property. |
| mappingExpression | [System.Linq.Expressions.Expression{System.Func{\`0,System.Collections.Generic.IEnumerable{\`\`1}}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`0,System.Collections.Generic.IEnumerable{``1}}}') | The expression for the source property. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TTargetMember | The generic argument of the target property type. |
| TSourceMember | The generic argument of the source property type. |

<a name='M-QueryMutator-Core-IMappingBuilder`2-ValidateMapping-QueryMutator-Core-ValidationMode-'></a>
### ValidateMapping(mode) `method`

##### Summary

Sets the validation mode to be used when creating the mappings.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mode | [QueryMutator.Core.ValidationMode](#T-QueryMutator-Core-ValidationMode 'QueryMutator.Core.ValidationMode') | The selected validation mode. |

<a name='T-QueryMutator-Core-IMappingBuilder`3'></a>
## IMappingBuilder\`3 `type`

##### Namespace

QueryMutator.Core

##### Summary

Represents an object that can be used to create a custom mapping between the 
`TSource`and `TTarget`types with a 
`TParam`parameter.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type of the mapping. |
| TTarget | The target type of the mapping. |
| TParam | The param type of the mapping. |

<a name='M-QueryMutator-Core-IMappingBuilder`3-MapMemberWithParameter``1-System-Linq-Expressions-Expression{System-Func{`1,``0}},System-Func{`2,System-Linq-Expressions-Expression{System-Func{`0,``0}}}-'></a>
### MapMemberWithParameter\`\`1(memberSelector,mappingExpression) `method`

##### Summary

Creates a mapping between a target and a source property using the. The `TParam`
type can be used for operations in the `mappingExpression`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| memberSelector | [System.Linq.Expressions.Expression{System.Func{\`1,\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression{System.Func{`1,``0}}') | The selector for the target property. |
| mappingExpression | [System.Func{\`2,System.Linq.Expressions.Expression{System.Func{\`0,\`\`0}}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{`2,System.Linq.Expressions.Expression{System.Func{`0,``0}}}') | The expression for the source property. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TMember | The type of the property. |

<a name='T-QueryMutator-Core-InvalidPropertyNameException'></a>
## InvalidPropertyNameException `type`

##### Namespace

QueryMutator.Core

##### Summary

Thrown when the property does not exist on the source type.

<a name='T-QueryMutator-Core-MapFromAttribute'></a>
## MapFromAttribute `type`

##### Namespace

QueryMutator.Core

##### Summary

Specifies a mapping from the supplied type to the attribute target.

<a name='M-QueryMutator-Core-MapFromAttribute-#ctor-System-Type-'></a>
### #ctor(sourceType) `constructor`

##### Summary

Specifies a mapping from the supplied type `sourceType`to the attribute target.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type of the source class to map from. |

<a name='P-QueryMutator-Core-MapFromAttribute-SourceType'></a>
### SourceType `property`

##### Summary

The type of the source class to map from.

<a name='T-QueryMutator-Core-MapperConfiguration'></a>
## MapperConfiguration `type`

##### Namespace

QueryMutator.Core

##### Summary

Represents the object used for configuring and creating a new mapper instance.

<a name='M-QueryMutator-Core-MapperConfiguration-#ctor-System-Action{QueryMutator-Core-IMapperConfigurationExpression},QueryMutator-Core-MapperConfigurationOptions-'></a>
### #ctor(expression,options) `constructor`

##### Summary

Represents the object used for configuring and creating a new mapper instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| expression | [System.Action{QueryMutator.Core.IMapperConfigurationExpression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{QueryMutator.Core.IMapperConfigurationExpression}') | The configuration expressions action to execute. |
| options | [QueryMutator.Core.MapperConfigurationOptions](#T-QueryMutator-Core-MapperConfigurationOptions 'QueryMutator.Core.MapperConfigurationOptions') | The additional options. Can be null. |

<a name='M-QueryMutator-Core-MapperConfiguration-CreateMapper'></a>
### CreateMapper() `method`

##### Summary

Creates a new mapper object using the registered mappings or the default mappings where necessary.

##### Returns

Returns a new [IMapper](#T-QueryMutator-Core-IMapper 'QueryMutator.Core.IMapper')object that contains the mappings.

##### Parameters

This method has no parameters.

<a name='T-QueryMutator-Core-MapperConfigurationOptions'></a>
## MapperConfigurationOptions `type`

##### Namespace

QueryMutator.Core

##### Summary

A configuration object containing settings, that can be passed when creating a new instance of 
[MapperConfiguration](#T-QueryMutator-Core-MapperConfiguration 'QueryMutator.Core.MapperConfiguration').

<a name='P-QueryMutator-Core-MapperConfigurationOptions-ValidationMode'></a>
### ValidationMode `property`

##### Summary

Specifies the validation mode to be used when creating the mappings.

<a name='T-QueryMutator-Core-MappingAlreadyExistsException'></a>
## MappingAlreadyExistsException `type`

##### Namespace

QueryMutator.Core

##### Summary

Thrown when another mapping with the same generic parameters already exists.

<a name='T-QueryMutator-Core-MappingNotFoundException'></a>
## MappingNotFoundException `type`

##### Namespace

QueryMutator.Core

##### Summary

Thrown when the mapping with the supplied generic arguments does not exist.

<a name='T-QueryMutator-Core-MappingValidationException'></a>
## MappingValidationException `type`

##### Namespace

QueryMutator.Core

##### Summary

Thrown when a mapping validation error occurs.

<a name='T-QueryMutator-Core-MapPropertyAttribute'></a>
## MapPropertyAttribute `type`

##### Namespace

QueryMutator.Core

##### Summary

Specifies a property mapping from the supplied property to the attribute target.
The defining class of the attribute target must be decorated with a [MapFromAttribute](#T-QueryMutator-Core-MapFromAttribute 'QueryMutator.Core.MapFromAttribute').

<a name='M-QueryMutator-Core-MapPropertyAttribute-#ctor-System-String-'></a>
### #ctor(propertyName) `constructor`

##### Summary

Specifies a property mapping from the supplied property `propertyName`to the attribute target.
The defining class of the attribute target must be decorated with a [MapFromAttribute](#T-QueryMutator-Core-MapFromAttribute 'QueryMutator.Core.MapFromAttribute').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the source property to map from. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [QueryMutator.Core.InvalidPropertyNameException](#T-QueryMutator-Core-InvalidPropertyNameException 'QueryMutator.Core.InvalidPropertyNameException') | Thrown when the property name does not exist on the source target. |

<a name='P-QueryMutator-Core-MapPropertyAttribute-PropertyName'></a>
### PropertyName `property`

##### Summary

The name of the property to map from.

<a name='T-QueryMutator-Core-QueryableExtensions'></a>
## QueryableExtensions `type`

##### Namespace

QueryMutator.Core

##### Summary

Globally usable extensions for custom projections.

<a name='M-QueryMutator-Core-QueryableExtensions-Select``2-System-Linq-IQueryable{``0},QueryMutator-Core-IMapping{``0,``1}-'></a>
### Select\`\`2(source,mapping) `method`

##### Summary

Projects each element of a sequence into a new form using the supplied `mapping`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The object to execute the given action on. |
| mapping | [QueryMutator.Core.IMapping{\`\`0,\`\`1}](#T-QueryMutator-Core-IMapping{``0,``1} 'QueryMutator.Core.IMapping{``0,``1}') | The mapping to use for the projection. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the given object `source`. |
| TTarget | The type of the destination object into which the source is projected. |

<a name='M-QueryMutator-Core-QueryableExtensions-Select``3-System-Linq-IQueryable{``0},QueryMutator-Core-IMapping{``0,``1,``2},``2-'></a>
### Select\`\`3(source,mapping,parameter) `method`

##### Summary

Projects each element of a sequence into a new form using the supplied `mapping`and `parameter`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Linq.IQueryable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.IQueryable 'System.Linq.IQueryable{``0}') | The object to execute the given action on. |
| mapping | [QueryMutator.Core.IMapping{\`\`0,\`\`1,\`\`2}](#T-QueryMutator-Core-IMapping{``0,``1,``2} 'QueryMutator.Core.IMapping{``0,``1,``2}') | The mapping to use for the projection. |
| parameter | [\`\`2](#T-``2 '``2') | An instance of the type `TParameter`required for the mapping. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The type of the given object `source`. |
| TTarget | The type of the destination object into which the source is projected. |
| TParameter | The type of the parameter used for the projection. |

<a name='T-QueryMutator-Core-QueryMutatorExtensions'></a>
## QueryMutatorExtensions `type`

##### Namespace

QueryMutator.Core

##### Summary

Globally usable extensions for configuration purposes.

<a name='M-QueryMutator-Core-QueryMutatorExtensions-UseQueryMutator-Microsoft-Extensions-DependencyInjection-IServiceCollection,QueryMutator-Core-MapperConfiguration,System-Boolean-'></a>
### UseQueryMutator(config,registerIndividualMappings) `method`

##### Summary

Creates the mapper instance using the supplied configuration `config`, then handles 
registering the mapper and the individual mappings to the service container `services`.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| config | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | The object that contains the mappings and options necessary to create the mapper. |
| registerIndividualMappings | [QueryMutator.Core.MapperConfiguration](#T-QueryMutator-Core-MapperConfiguration 'QueryMutator.Core.MapperConfiguration') | Specifies if individual mappings should be registered to the DI container. |

<a name='T-QueryMutator-Core-ValidationMode'></a>
## ValidationMode `type`

##### Namespace

QueryMutator.Core

##### Summary

Determines the validation mode when mapping objects.

<a name='F-QueryMutator-Core-ValidationMode-Destination'></a>
### Destination `constants`

##### Summary

All destination properties have to be mapped.

<a name='F-QueryMutator-Core-ValidationMode-None'></a>
### None `constants`

##### Summary

No validation is used.

<a name='F-QueryMutator-Core-ValidationMode-Source'></a>
### Source `constants`

##### Summary

All source properties have to be mapped.
