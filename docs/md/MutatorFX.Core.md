<a name='assembly'></a>
# MutatorFX.Core

## Contents

- [Assertions](#T-MutatorFX-ExceptionHandling-Assertions 'MutatorFX.ExceptionHandling.Assertions')
  - [EnsureNoneNull\`\`1(parameters)](#M-MutatorFX-ExceptionHandling-Assertions-EnsureNoneNull``1-``0- 'MutatorFX.ExceptionHandling.Assertions.EnsureNoneNull``1(``0)')
  - [EnsureNotNull\`\`1(parameter)](#M-MutatorFX-ExceptionHandling-Assertions-EnsureNotNull``1-``0- 'MutatorFX.ExceptionHandling.Assertions.EnsureNotNull``1(``0)')
  - [EnsureNotNull\`\`1(parameter,parameterName)](#M-MutatorFX-ExceptionHandling-Assertions-EnsureNotNull``1-``0,System-String- 'MutatorFX.ExceptionHandling.Assertions.EnsureNotNull``1(``0,System.String)')
  - [EnsureNotNull\`\`1(parameter,parameterName,message)](#M-MutatorFX-ExceptionHandling-Assertions-EnsureNotNull``1-``0,System-String,System-String- 'MutatorFX.ExceptionHandling.Assertions.EnsureNotNull``1(``0,System.String,System.String)')
- [ExceptionHandlingExtensions](#T-MutatorFX-ExceptionHandling-ExceptionHandlingExtensions 'MutatorFX.ExceptionHandling.ExceptionHandlingExtensions')
  - [WithData\`\`1(exception,data)](#M-MutatorFX-ExceptionHandling-ExceptionHandlingExtensions-WithData``1-``0,System-Object- 'MutatorFX.ExceptionHandling.ExceptionHandlingExtensions.WithData``1(``0,System.Object)')
- [GeneralFluentExtensions](#T-MutatorFX-Coding-GeneralFluentExtensions 'MutatorFX.Coding.GeneralFluentExtensions')
  - [Branch\`\`1(obj,predicate,actionIf,actionElse)](#M-MutatorFX-Coding-GeneralFluentExtensions-Branch``1-``0,System-Func{``0,System-Boolean},System-Action{``0},System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.Branch``1(``0,System.Func{``0,System.Boolean},System.Action{``0},System.Action{``0})')
  - [Branch\`\`2(obj,predicate,funcIf,funcElse)](#M-MutatorFX-Coding-GeneralFluentExtensions-Branch``2-``0,System-Func{``0,System-Boolean},System-Func{``0,``1},System-Func{``0,``1}- 'MutatorFX.Coding.GeneralFluentExtensions.Branch``2(``0,System.Func{``0,System.Boolean},System.Func{``0,``1},System.Func{``0,``1})')
  - [BranchAsync\`\`1(obj,predicate,actionIf,actionElse)](#M-MutatorFX-Coding-GeneralFluentExtensions-BranchAsync``1-``0,System-Func{``0,System-Threading-Tasks-Task{System-Boolean}},System-Func{``0,System-Threading-Tasks-Task},System-Func{``0,System-Threading-Tasks-Task}- 'MutatorFX.Coding.GeneralFluentExtensions.BranchAsync``1(``0,System.Func{``0,System.Threading.Tasks.Task{System.Boolean}},System.Func{``0,System.Threading.Tasks.Task},System.Func{``0,System.Threading.Tasks.Task})')
  - [BranchAsync\`\`2(obj,predicate,funcIf,funcElse)](#M-MutatorFX-Coding-GeneralFluentExtensions-BranchAsync``2-``0,System-Func{``0,System-Threading-Tasks-Task{System-Boolean}},System-Func{``0,System-Threading-Tasks-Task{``1}},System-Func{``0,System-Threading-Tasks-Task{``1}}- 'MutatorFX.Coding.GeneralFluentExtensions.BranchAsync``2(``0,System.Func{``0,System.Threading.Tasks.Task{System.Boolean}},System.Func{``0,System.Threading.Tasks.Task{``1}},System.Func{``0,System.Threading.Tasks.Task{``1}})')
  - [Do\`\`1(obj,action)](#M-MutatorFX-Coding-GeneralFluentExtensions-Do``1-``0,System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.Do``1(``0,System.Action{``0})')
  - [DoAsync\`\`1(obj,action)](#M-MutatorFX-Coding-GeneralFluentExtensions-DoAsync``1-``0,System-Func{``0,System-Threading-Tasks-Task}- 'MutatorFX.Coding.GeneralFluentExtensions.DoAsync``1(``0,System.Func{``0,System.Threading.Tasks.Task})')
  - [DoAwait\`\`1(obj,func)](#M-MutatorFX-Coding-GeneralFluentExtensions-DoAwait``1-``0,System-Func{``0,System-Threading-Tasks-Task}- 'MutatorFX.Coding.GeneralFluentExtensions.DoAwait``1(``0,System.Func{``0,System.Threading.Tasks.Task})')
  - [For\`\`1(source,action)](#M-MutatorFX-Coding-GeneralFluentExtensions-For``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.For``1(System.Collections.Generic.IEnumerable{``0},System.Action{``0})')
  - [For\`\`1(source,action,lazy)](#M-MutatorFX-Coding-GeneralFluentExtensions-For``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0},System-Boolean- 'MutatorFX.Coding.GeneralFluentExtensions.For``1(System.Collections.Generic.IEnumerable{``0},System.Action{``0},System.Boolean)')
  - [ForInternal\`\`1(source,action)](#M-MutatorFX-Coding-GeneralFluentExtensions-ForInternal``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.ForInternal``1(System.Collections.Generic.IEnumerable{``0},System.Action{``0})')
  - [Pipe\`\`2(obj,function)](#M-MutatorFX-Coding-GeneralFluentExtensions-Pipe``2-``0,System-Func{``0,``1}- 'MutatorFX.Coding.GeneralFluentExtensions.Pipe``2(``0,System.Func{``0,``1})')
  - [PipeAsync\`\`2(obj,function)](#M-MutatorFX-Coding-GeneralFluentExtensions-PipeAsync``2-``0,System-Func{``0,System-Threading-Tasks-Task{``1}}- 'MutatorFX.Coding.GeneralFluentExtensions.PipeAsync``2(``0,System.Func{``0,System.Threading.Tasks.Task{``1}})')
  - [PipeAwait\`\`2(obj,func)](#M-MutatorFX-Coding-GeneralFluentExtensions-PipeAwait``2-``0,System-Func{``0,System-Threading-Tasks-Task{``1}}- 'MutatorFX.Coding.GeneralFluentExtensions.PipeAwait``2(``0,System.Func{``0,System.Threading.Tasks.Task{``1}})')
  - [Using\`\`1(disposable,action)](#M-MutatorFX-Coding-GeneralFluentExtensions-Using``1-``0,System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.Using``1(``0,System.Action{``0})')
  - [Using\`\`2(disposable,function)](#M-MutatorFX-Coding-GeneralFluentExtensions-Using``2-``0,System-Func{``0,``1}- 'MutatorFX.Coding.GeneralFluentExtensions.Using``2(``0,System.Func{``0,``1})')
  - [UsingAsync\`\`1(disposable,function)](#M-MutatorFX-Coding-GeneralFluentExtensions-UsingAsync``1-``0,System-Func{``0,System-Threading-Tasks-Task}- 'MutatorFX.Coding.GeneralFluentExtensions.UsingAsync``1(``0,System.Func{``0,System.Threading.Tasks.Task})')
  - [UsingAsync\`\`2(disposable,function)](#M-MutatorFX-Coding-GeneralFluentExtensions-UsingAsync``2-``0,System-Func{``0,System-Threading-Tasks-Task{``1}}- 'MutatorFX.Coding.GeneralFluentExtensions.UsingAsync``2(``0,System.Func{``0,System.Threading.Tasks.Task{``1}})')
- [TypeReflectionExtensions](#T-MutatorFX-Reflection-TypeReflectionExtensions 'MutatorFX.Reflection.TypeReflectionExtensions')
  - [GetPropertyChain(type,text,bindingFlags)](#M-MutatorFX-Reflection-TypeReflectionExtensions-GetPropertyChain-System-Type,System-String,System-Nullable{System-Reflection-BindingFlags}- 'MutatorFX.Reflection.TypeReflectionExtensions.GetPropertyChain(System.Type,System.String,System.Nullable{System.Reflection.BindingFlags})')
  - [GetPropertyChains(type,text,bindingFlags)](#M-MutatorFX-Reflection-TypeReflectionExtensions-GetPropertyChains-System-Type,System-String,System-Nullable{System-Reflection-BindingFlags}- 'MutatorFX.Reflection.TypeReflectionExtensions.GetPropertyChains(System.Type,System.String,System.Nullable{System.Reflection.BindingFlags})')

<a name='T-MutatorFX-ExceptionHandling-Assertions'></a>
## Assertions `type`

##### Namespace

MutatorFX.ExceptionHandling

##### Summary

This class contains static helper methods to validate simple assertions for generating Exceptions like
[ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException')or [ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException').
It is suggested that you use the assertions as follows:



```
using static MutatorFX.ExceptionHandling.Assertions;
void Method(string param1, object param2)
{
    EnsureNoneNull(new { param1, param2 });
}
void Method2(string parameter)
{
    EnsureNotNull(parameter, nameof(parameter));
} 
```

<a name='M-MutatorFX-ExceptionHandling-Assertions-EnsureNoneNull``1-``0-'></a>
### EnsureNoneNull\`\`1(parameters) `method`

##### Summary

Throws an [AggregateException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.AggregateException 'System.AggregateException')if any of the passed `parameters`object's properties are null.
Should be used with an anonymous object containing
Usage:



```
using static MutatorFX.ExceptionHandling.Assertions;
void Method(string param1, object param2)
{
    EnsureNoneNull(new { param1, param2 });
} 
```

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parameters | [\`\`0](#T-``0 '``0') | The object containing the parameters in its properties to check for null. 
Should be an anonymous object constructed inline from the names of the parameters. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the given parameters object is null. |
| [System.AggregateException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.AggregateException 'System.AggregateException') | Thrown when any of the given parameters object's properties are null. 
Contains [ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException')instances which show the invalid parameters. |

<a name='M-MutatorFX-ExceptionHandling-Assertions-EnsureNotNull``1-``0-'></a>
### EnsureNotNull\`\`1(parameter) `method`

##### Summary

Throws an [ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException')if the passed parameter was null.
Consider using the [EnsureNotNull\`\`1](#M-MutatorFX-ExceptionHandling-Assertions-EnsureNotNull``1-``0,System-String- 'MutatorFX.ExceptionHandling.Assertions.EnsureNotNull``1(``0,System.String)')overload for named parameters.

##### Returns

The parameter if it was not null, throws an [ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException')otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parameter | [\`\`0](#T-``0 '``0') | The parameter which should not be null. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the given parameter object is null. |

<a name='M-MutatorFX-ExceptionHandling-Assertions-EnsureNotNull``1-``0,System-String-'></a>
### EnsureNotNull\`\`1(parameter,parameterName) `method`

##### Summary

Throws an [ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException')if the passed parameter was null.

##### Returns

The parameter if it was not null, throws an [ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException')otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parameter | [\`\`0](#T-``0 '``0') | The parameter which should not be null. |
| parameterName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The (outer) name of the parameter. Should not be null :) |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the given parameter object is null. |

<a name='M-MutatorFX-ExceptionHandling-Assertions-EnsureNotNull``1-``0,System-String,System-String-'></a>
### EnsureNotNull\`\`1(parameter,parameterName,message) `method`

##### Summary

Throws an [ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException')if the passed parameter was null.

##### Returns

The parameter if it was not null, throws an [ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException')otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parameter | [\`\`0](#T-``0 '``0') | The parameter which should not be null. |
| parameterName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The (outer) name of the parameter. Should not be null :) |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The message to set on the resulting [ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException'). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown when the given parameter object is null. |

<a name='T-MutatorFX-ExceptionHandling-ExceptionHandlingExtensions'></a>
## ExceptionHandlingExtensions `type`

##### Namespace

MutatorFX.ExceptionHandling

##### Summary

Contains helper methods to use when throwing and handling [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception')s.

<a name='M-MutatorFX-ExceptionHandling-ExceptionHandlingExtensions-WithData``1-``0,System-Object-'></a>
### WithData\`\`1(exception,data) `method`

##### Summary

Appends the `data`object's properties to the `exception`'s [Data](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception.Data 'System.Exception.Data')dictionary.

##### Returns

The `exception`with data appended from the `data`object's properties to its [Data](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception.Data 'System.Exception.Data')property. 
If the `data`was null, the `exception`is returned as is. 
If the `exception`was null, null will be returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| exception | [\`\`0](#T-``0 '``0') | The exception to append the data to. Can be null, in this case null will be returned. |
| data | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The data to append to the exception. Can be null, in this case the exception object will be returned as is. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TException | The type of the [Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception')to extend. Should be inferred by using as an extension method. |

<a name='T-MutatorFX-Coding-GeneralFluentExtensions'></a>
## GeneralFluentExtensions `type`

##### Namespace

MutatorFX.Coding

##### Summary

Globally usable extensions for creating fluent style APIs.

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-Branch``1-``0,System-Func{``0,System-Boolean},System-Action{``0},System-Action{``0}-'></a>
### Branch\`\`1(obj,predicate,actionIf,actionElse) `method`

##### Summary

Execute an action with the given object as parameter if a precondition succeeds, then return the object.
Optionally execute another action, like an if-else statement.
Useful for creating fluent APIs and shortening two-liners.
Note that the input object `obj`can only be mutated by the provided actions if it is a reference type.

##### Returns

The object itself after the invokation of either or none of the actions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to execute the given action on. Can be null. |
| predicate | [System.Func{\`\`0,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Boolean}') | The precondition to check. |
| actionIf | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to execute on the object `obj`when the predicate resolves to true. |
| actionElse | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The optional action to execute on the object `obj`when the predicate resolves to false. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the given object `obj`. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-Branch``2-``0,System-Func{``0,System-Boolean},System-Func{``0,``1},System-Func{``0,``1}-'></a>
### Branch\`\`2(obj,predicate,funcIf,funcElse) `method`

##### Summary

Branch a statement based on the current value.

##### Returns

The result of the appropriate invokation. If no else branch was specified and precondition fails, the default of type `TResult`is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to base the branching on. |
| predicate | [System.Func{\`\`0,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Boolean}') | The value to check for branching. |
| funcIf | [System.Func{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1}') | The function to execute when precondition succeeds. |
| funcElse | [System.Func{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1}') | The function to execute when precondition fails. Optional. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the given object `obj`. Should be inferred. |
| TResult | The type of the return value. In most cases, should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-BranchAsync``1-``0,System-Func{``0,System-Threading-Tasks-Task{System-Boolean}},System-Func{``0,System-Threading-Tasks-Task},System-Func{``0,System-Threading-Tasks-Task}-'></a>
### BranchAsync\`\`1(obj,predicate,actionIf,actionElse) `method`

##### Summary

The async pair of [Branch\`\`1](#M-MutatorFX-Coding-GeneralFluentExtensions-Branch``1-``0,System-Func{``0,System-Boolean},System-Action{``0},System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.Branch``1(``0,System.Func{``0,System.Boolean},System.Action{``0},System.Action{``0})').
Execute an action with the given object as parameter if a precondition succeeds, then return the object.
Optionally execute another action, like an if-else statement.
Useful for creating fluent APIs and shortening two-liners.
Note that the input object `obj`can only be mutated by the provided actions if it is a reference type.

##### Returns

The object itself after the invokation of either or none of the actions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to execute the given action on. Can be null. |
| predicate | [System.Func{\`\`0,System.Threading.Tasks.Task{System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task{System.Boolean}}') | The precondition to check. |
| actionIf | [System.Func{\`\`0,System.Threading.Tasks.Task}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task}') | The action to execute on the object `obj`when the predicate resolves to true. |
| actionElse | [System.Func{\`\`0,System.Threading.Tasks.Task}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task}') | The optional action to execute on the object `obj`when the predicate resolves to false. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the given object `obj`. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-BranchAsync``2-``0,System-Func{``0,System-Threading-Tasks-Task{System-Boolean}},System-Func{``0,System-Threading-Tasks-Task{``1}},System-Func{``0,System-Threading-Tasks-Task{``1}}-'></a>
### BranchAsync\`\`2(obj,predicate,funcIf,funcElse) `method`

##### Summary

The async pair of [Branch\`\`2](#M-MutatorFX-Coding-GeneralFluentExtensions-Branch``2-``0,System-Func{``0,System-Boolean},System-Func{``0,``1},System-Func{``0,``1}- 'MutatorFX.Coding.GeneralFluentExtensions.Branch``2(``0,System.Func{``0,System.Boolean},System.Func{``0,``1},System.Func{``0,``1})').
Branch a statement based on the current value.

##### Returns

The result of the appropriate invokation. If no else branch was specified and precondition fails, the default of type `TResult`is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to base the branching on. |
| predicate | [System.Func{\`\`0,System.Threading.Tasks.Task{System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task{System.Boolean}}') | The value to check for branching. |
| funcIf | [System.Func{\`\`0,System.Threading.Tasks.Task{\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task{``1}}') | The function to execute when precondition succeeds. |
| funcElse | [System.Func{\`\`0,System.Threading.Tasks.Task{\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task{``1}}') | The function to execute when precondition fails. Optional. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the given object `obj`. Should be inferred. |
| TResult | The type of the return value. In most cases, should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-Do``1-``0,System-Action{``0}-'></a>
### Do\`\`1(obj,action) `method`

##### Summary

Execute an action with the given object as parameter, then return the object.
Useful for creating fluent APIs and shortening two-liners.
Note that the input object `obj`can only be mutated by the provided `action`if it is a reference type.

##### Returns

The object itself after the invokation of the action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to execute the given action on. Can be null. |
| action | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to execute on the object `obj`. Usually a method with 
no return value or with a return value that should be ignored. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the given object `obj`. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-DoAsync``1-``0,System-Func{``0,System-Threading-Tasks-Task}-'></a>
### DoAsync\`\`1(obj,action) `method`

##### Summary

The asynchronous pair of [Do\`\`1](#M-MutatorFX-Coding-GeneralFluentExtensions-Do``1-``0,System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.Do``1(``0,System.Action{``0})').
Useful for creating fluent APIs and shortening two-liners.
Note that the input object `obj`can only be mutated by the provided `action`if it is a reference type.

##### Returns

The object itself after the invokation and awaiting of the asynchronous function.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to execute the given action on. Can be null. |
| action | [System.Func{\`\`0,System.Threading.Tasks.Task}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task}') | The (generally) async function to execute on the object `obj`. 
If the task has a return value, it is ignored. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the given object `obj`. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-DoAwait``1-``0,System-Func{``0,System-Threading-Tasks-Task}-'></a>
### DoAwait\`\`1(obj,func) `method`

##### Summary

Awaits an asynchrounous operation on an object and returns the object. Uses [GetAwaiter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.Tasks.Task.GetAwaiter 'System.Threading.Tasks.Task.GetAwaiter')and [GetResult](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.CompilerServices.TaskAwaiter.GetResult 'System.Runtime.CompilerServices.TaskAwaiter.GetResult').

##### Returns

The object `obj`after the async function `func`is executed and awaited. 
If type `T`is not a reference type, the input will be returned and won't be mutated.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to use. Should not be null. |
| func | [System.Func{\`\`0,System.Threading.Tasks.Task}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task}') | The async function to execute. Should not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the object to use. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-For``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0}-'></a>
### For\`\`1(source,action) `method`

##### Summary

Execute the provided `action`for all elements in the `source`collection.
Useful to create fluent APIs and shorten code by replacing foreach loops. The action is executed and the element is returned for each element.
Used instead of [Select\`\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Enumerable.Select``2 'System.Linq.Enumerable.Select``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})')when the `source`should not lazily be enumerated.
Note that the input objects in `source`can only be mutated by the provided `action`if `T`is a reference type.

##### Returns

Returns the elements of `source`, after each has been invoked on `action`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | The collection to enumerate and execute the provided `action`on. Can not be null. |
| action | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to execute on the `source`collection. Can not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the collection elements. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-For``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0},System-Boolean-'></a>
### For\`\`1(source,action,lazy) `method`

##### Summary

Execute the provided `action`for all elements in the `source`collection.
Useful to create fluent APIs and shorten code by replacing foreach loops. The action is executed and the element is returned for each element.
Used instead of [Select\`\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Enumerable.Select``2 'System.Linq.Enumerable.Select``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})')and the `source`can optionally be lazily enumerated.
Note that the input objects in `source`can only be mutated by the provided `action`if `T`is a reference type.

##### Returns

Returns the elements of `source`one by one after being invoked on `action`, or after all has been invoked depending on the value of `lazy`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | The collection to enumerate and execute the provided `action`on. Can not be null. |
| action | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to execute on the `source`collection. Can not be null. |
| lazy | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Using lazy evaluation executes the action once as the `source`is being enumerated, otherwise a full enumeration happens and each element is called on the `action`. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the collection elements. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-ForInternal``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0}-'></a>
### ForInternal\`\`1(source,action) `method`

##### Summary

Internal helper method for the method [For\`\`1](#M-MutatorFX-Coding-GeneralFluentExtensions-For``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.For``1(System.Collections.Generic.IEnumerable{``0},System.Action{``0})'). Used for reducing the number of parameter null checks.
Note that the input objects in `source`can only be mutated by the provided `action`if `T`is a reference type.

##### Returns

The parameter `source`after invoking `action`with its elements. Evaluated lazily.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | The collection to enumerate and execute the provided `action`on. Can not be null, but not checked. |
| action | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to execute on the `source`collection. Can not be null, but not checked. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the collection elements. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-Pipe``2-``0,System-Func{``0,``1}-'></a>
### Pipe\`\`2(obj,function) `method`

##### Summary

Execute a function with the given object as parameter, and return the result.
Useful to create fluent APIs and shorten code by closing on the object `obj`.
Instead of a simple invocation, you can create a closure on the object `obj`and reuse the variable in the `function`scope.
Note that the input object `obj`can only be mutated by the provided `function`if it is a reference type.

##### Returns

Returns the result of the function invokation of `function`with the parameter `obj`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to call the provided function `function`on. If the object is not a reference type, the input won't be mutated. |
| function | [System.Func{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1}') | The function to call with the parameter `obj`and return the resulting value of. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the object `obj`. Should be inferred. |
| TResult | The type of the invokation result of `function`. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-PipeAsync``2-``0,System-Func{``0,System-Threading-Tasks-Task{``1}}-'></a>
### PipeAsync\`\`2(obj,function) `method`

##### Summary

The asynchronous pair of [Pipe\`\`2](#M-MutatorFX-Coding-GeneralFluentExtensions-Pipe``2-``0,System-Func{``0,``1}- 'MutatorFX.Coding.GeneralFluentExtensions.Pipe``2(``0,System.Func{``0,``1})').
/// Execute and await an asynchronous function with the given object as parameter, and return the result.
Useful to create fluent APIs and shorten code by closing on the object `obj`.
Instead of a simple invocation, you can create a closure on the object `obj`and reuse the variable in the `function`scope.
Note that the input object `obj`can only be mutated by the provided `function`if it is a reference type.

##### Returns

Returns the result of the function invokation of `function`with the parameter `obj`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to call the provided function `function`on. |
| function | [System.Func{\`\`0,System.Threading.Tasks.Task{\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task{``1}}') | The function to call with the parameter `obj`and return the resulting value of. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the object `obj`. Should be inferred. |
| TResult | The type of the invokation result of `function`. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-PipeAwait``2-``0,System-Func{``0,System-Threading-Tasks-Task{``1}}-'></a>
### PipeAwait\`\`2(obj,func) `method`

##### Summary

Awaits an asynchrounous operation on an object and returns the result of the operation. Uses [GetAwaiter](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.Tasks.Task.GetAwaiter 'System.Threading.Tasks.Task.GetAwaiter')and [GetResult](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Runtime.CompilerServices.TaskAwaiter.GetResult 'System.Runtime.CompilerServices.TaskAwaiter.GetResult').

##### Returns

The result of the async function `func`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to use Should not be null. |
| func | [System.Func{\`\`0,System.Threading.Tasks.Task{\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task{``1}}') | The async function to execute. Should not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the object to use. Should be inferred. |
| TResult | The type of result of the function `func`. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-Using``1-``0,System-Action{``0}-'></a>
### Using\`\`1(disposable,action) `method`

##### Summary

Invokes a synchronous action on a disposable object. The object will be used in a using block.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposable | [\`\`0](#T-``0 '``0') | The object to use. Will be disposed of by the end of the call. Should not be null. |
| action | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to invoke on the disposable object in a using block. Should not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the disposable object to use. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-Using``2-``0,System-Func{``0,``1}-'></a>
### Using\`\`2(disposable,function) `method`

##### Summary

Invokes a synchronous function on a disposable object. The object will be used in a using block.

##### Returns

The result of calling the `function`on the `disposable`object.
When the object is returned to the caller, the disposable object is disposed of.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposable | [\`\`0](#T-``0 '``0') | The object to use. Will be disposed of by the end of the call. Should not be null. |
| function | [System.Func{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1}') | The action to invoke on the disposable object in a using block. Should not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the disposable object to use. Should be inferred. |
| TResult | The result type of the `function`call on the object. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-UsingAsync``1-``0,System-Func{``0,System-Threading-Tasks-Task}-'></a>
### UsingAsync\`\`1(disposable,function) `method`

##### Summary

Invokes an asynchronous action on a disposable object. The object will be used in a using block.

##### Returns

When control is returned to the caller, the disposable object is disposed of and the task returned by `function`awaited.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposable | [\`\`0](#T-``0 '``0') | The object to use. Will be disposed of by the end of the call. Should not be null. |
| function | [System.Func{\`\`0,System.Threading.Tasks.Task}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task}') | The action to invoke on the disposable object in a using block. Should not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the disposable object to use. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-UsingAsync``2-``0,System-Func{``0,System-Threading-Tasks-Task{``1}}-'></a>
### UsingAsync\`\`2(disposable,function) `method`

##### Summary

Invokes an asynchronous function on a disposable object. The object will be used in a using block.

##### Returns

When control is returned to the caller, the disposable object is disposed of and the result of the task returned by `function`is returned.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposable | [\`\`0](#T-``0 '``0') | The object to use. Will be disposed of by the end of the call. Should not be null. |
| function | [System.Func{\`\`0,System.Threading.Tasks.Task{\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task{``1}}') | The action to invoke on the disposable object in a using block. Should not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the disposable object to use. Should be inferred. |
| TResult | The result type of the asynchronous `function`call on the object. Should be inferred. |

<a name='T-MutatorFX-Reflection-TypeReflectionExtensions'></a>
## TypeReflectionExtensions `type`

##### Namespace

MutatorFX.Reflection

##### Summary

Globally usable helper extensions, useful when using reflection and [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type')objects.

<a name='M-MutatorFX-Reflection-TypeReflectionExtensions-GetPropertyChain-System-Type,System-String,System-Nullable{System-Reflection-BindingFlags}-'></a>
### GetPropertyChain(type,text,bindingFlags) `method`

##### Summary

Gets the first available property chain that matches the start of the given text. The text should be the concatenation of the property names. 
In case of multiple matches, the first match is selected by ordering the properties by ascending order of the length of their names.
In case of no matches are found, an [InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException')is thrown.

##### Returns

The property chain in order.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type that should contain the properties described by the `text`. |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The string containing the exact names of the chained properties (without separators). |
| bindingFlags | [System.Nullable{System.Reflection.BindingFlags}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Reflection.BindingFlags}') | The to use when looking for matching properties. |

##### Remarks

This method uses recursion, and calls [GetPropertyChains](#M-MutatorFX-Reflection-TypeReflectionExtensions-GetPropertyChains-System-Type,System-String,System-Nullable{System-Reflection-BindingFlags}- 'MutatorFX.Reflection.TypeReflectionExtensions.GetPropertyChains(System.Type,System.String,System.Nullable{System.Reflection.BindingFlags})')internally.

<a name='M-MutatorFX-Reflection-TypeReflectionExtensions-GetPropertyChains-System-Type,System-String,System-Nullable{System-Reflection-BindingFlags}-'></a>
### GetPropertyChains(type,text,bindingFlags) `method`

##### Summary

Gets all the available property chains that matches the given text. The text should be the concatenation of the property names. 
The matches are ordered by ascending order of the length of their propertynames.

##### Returns

The matching property chains.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type that should contain the properties described by the `text`. |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The string containing the exact names of the chained properties (without separators). |
| bindingFlags | [System.Nullable{System.Reflection.BindingFlags}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Reflection.BindingFlags}') | The to use when looking for matching properties. |
