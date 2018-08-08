<a name='assembly'></a>
# MutatorFX.Core

## Contents

- [GeneralFluentExtensions](#T-MutatorFX-Coding-GeneralFluentExtensions 'MutatorFX.Coding.GeneralFluentExtensions')
  - [Branch\`\`1(obj,predicate,actionIf,actionElse)](#M-MutatorFX-Coding-GeneralFluentExtensions-Branch``1-``0,System-Func{``0,System-Boolean},System-Action{``0},System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.Branch``1(``0,System.Func{``0,System.Boolean},System.Action{``0},System.Action{``0})')
  - [Branch\`\`2(obj,predicate,funcIf,funcElse)](#M-MutatorFX-Coding-GeneralFluentExtensions-Branch``2-``0,System-Func{``0,System-Boolean},System-Func{``0,``1},System-Func{``0,``1}- 'MutatorFX.Coding.GeneralFluentExtensions.Branch``2(``0,System.Func{``0,System.Boolean},System.Func{``0,``1},System.Func{``0,``1})')
  - [BranchAsync\`\`1(obj,predicate,actionIf,actionElse)](#M-MutatorFX-Coding-GeneralFluentExtensions-BranchAsync``1-``0,System-Func{``0,System-Threading-Tasks-Task{System-Boolean}},System-Func{``0,System-Threading-Tasks-Task},System-Func{``0,System-Threading-Tasks-Task}- 'MutatorFX.Coding.GeneralFluentExtensions.BranchAsync``1(``0,System.Func{``0,System.Threading.Tasks.Task{System.Boolean}},System.Func{``0,System.Threading.Tasks.Task},System.Func{``0,System.Threading.Tasks.Task})')
  - [BranchAsync\`\`2(obj,predicate,funcIf,funcElse)](#M-MutatorFX-Coding-GeneralFluentExtensions-BranchAsync``2-``0,System-Func{``0,System-Threading-Tasks-Task{System-Boolean}},System-Func{``0,System-Threading-Tasks-Task{``1}},System-Func{``0,System-Threading-Tasks-Task{``1}}- 'MutatorFX.Coding.GeneralFluentExtensions.BranchAsync``2(``0,System.Func{``0,System.Threading.Tasks.Task{System.Boolean}},System.Func{``0,System.Threading.Tasks.Task{``1}},System.Func{``0,System.Threading.Tasks.Task{``1}})')
  - [Do\`\`1(obj,action)](#M-MutatorFX-Coding-GeneralFluentExtensions-Do``1-``0,System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.Do``1(``0,System.Action{``0})')
  - [DoAsync\`\`1(obj,action)](#M-MutatorFX-Coding-GeneralFluentExtensions-DoAsync``1-``0,System-Func{``0,System-Threading-Tasks-Task}- 'MutatorFX.Coding.GeneralFluentExtensions.DoAsync``1(``0,System.Func{``0,System.Threading.Tasks.Task})')
  - [For\`\`1(source,action)](#M-MutatorFX-Coding-GeneralFluentExtensions-For``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.For``1(System.Collections.Generic.IEnumerable{``0},System.Action{``0})')
  - [For\`\`1(source,action,lazy)](#M-MutatorFX-Coding-GeneralFluentExtensions-For``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0},System-Boolean- 'MutatorFX.Coding.GeneralFluentExtensions.For``1(System.Collections.Generic.IEnumerable{``0},System.Action{``0},System.Boolean)')
  - [ForInternal\`\`1(source,action)](#M-MutatorFX-Coding-GeneralFluentExtensions-ForInternal``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.ForInternal``1(System.Collections.Generic.IEnumerable{``0},System.Action{``0})')
  - [Pipe\`\`2(obj,function)](#M-MutatorFX-Coding-GeneralFluentExtensions-Pipe``2-``0,System-Func{``0,``1}- 'MutatorFX.Coding.GeneralFluentExtensions.Pipe``2(``0,System.Func{``0,``1})')
  - [PipeAsync\`\`2(obj,function)](#M-MutatorFX-Coding-GeneralFluentExtensions-PipeAsync``2-``0,System-Func{``0,System-Threading-Tasks-Task{``1}}- 'MutatorFX.Coding.GeneralFluentExtensions.PipeAsync``2(``0,System.Func{``0,System.Threading.Tasks.Task{``1}})')
- [TypeReflectionExtensions](#T-MutatorFX-Reflection-TypeReflectionExtensions 'MutatorFX.Reflection.TypeReflectionExtensions')
  - [GetPropertyChain(type,text,bindingFlags)](#M-MutatorFX-Reflection-TypeReflectionExtensions-GetPropertyChain-System-Type,System-String,System-Nullable{System-Reflection-BindingFlags}- 'MutatorFX.Reflection.TypeReflectionExtensions.GetPropertyChain(System.Type,System.String,System.Nullable{System.Reflection.BindingFlags})')
  - [GetPropertyChains(type,text,bindingFlags)](#M-MutatorFX-Reflection-TypeReflectionExtensions-GetPropertyChains-System-Type,System-String,System-Nullable{System-Reflection-BindingFlags}- 'MutatorFX.Reflection.TypeReflectionExtensions.GetPropertyChains(System.Type,System.String,System.Nullable{System.Reflection.BindingFlags})')

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
            Note that the input object `obj` can only be mutated by the provided actions if it is a reference type.

##### Returns

The object itself after the invokation of either or none of the actions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to execute the given action on. Can be null. |
| predicate | [System.Func{\`\`0,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Boolean}') | The precondition to check. |
| actionIf | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to execute on the object `obj` when the predicate resolves to true. |
| actionElse | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The optional action to execute on the object `obj` when the predicate resolves to false. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the given object `obj`. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-Branch``2-``0,System-Func{``0,System-Boolean},System-Func{``0,``1},System-Func{``0,``1}-'></a>
### Branch\`\`2(obj,predicate,funcIf,funcElse) `method`

##### Summary

Branch a statement based on the current value.

##### Returns

The result of the appropriate invokation. If no else branch was specified and precondition fails, the default of type `TResult` is returned.

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
            Note that the input object `obj` can only be mutated by the provided actions if it is a reference type.

##### Returns

The object itself after the invokation of either or none of the actions.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to execute the given action on. Can be null. |
| predicate | [System.Func{\`\`0,System.Threading.Tasks.Task{System.Boolean}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task{System.Boolean}}') | The precondition to check. |
| actionIf | [System.Func{\`\`0,System.Threading.Tasks.Task}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task}') | The action to execute on the object `obj` when the predicate resolves to true. |
| actionElse | [System.Func{\`\`0,System.Threading.Tasks.Task}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task}') | The optional action to execute on the object `obj` when the predicate resolves to false. |

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

The result of the appropriate invokation. If no else branch was specified and precondition fails, the default of type `TResult` is returned.

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
            Note that the input object `obj` can only be mutated by the provided `action` if it is a reference type.

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
            Note that the input object `obj` can only be mutated by the provided `action` if it is a reference type.

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

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-For``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0}-'></a>
### For\`\`1(source,action) `method`

##### Summary

Execute the provided `action` for all elements in the `source` collection.
            Useful to create fluent APIs and shorten code by replacing foreach loops. The action is executed and the element is returned for each element.
            Used instead of [Select\`\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Enumerable.Select``2 'System.Linq.Enumerable.Select``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})') when the `source` should not lazily be enumerated.
            Note that the input objects in `source` can only be mutated by the provided `action` if `T` is a reference type.

##### Returns

Returns the elements of `source`, after each has been invoked on `action`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | The collection to enumerate and execute the provided `action` on. Can not be null. |
| action | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to execute on the `source` collection. Can not be null. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the collection elements. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-For``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0},System-Boolean-'></a>
### For\`\`1(source,action,lazy) `method`

##### Summary

Execute the provided `action` for all elements in the `source` collection.
            Useful to create fluent APIs and shorten code by replacing foreach loops. The action is executed and the element is returned for each element.
            Used instead of [Select\`\`2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Enumerable.Select``2 'System.Linq.Enumerable.Select``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})') and the `source` can optionally be lazily enumerated.
            Note that the input objects in `source` can only be mutated by the provided `action` if `T` is a reference type.

##### Returns

Returns the elements of `source` one by one after being invoked on `action`, or after all has been invoked depending on the value of `lazy`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | The collection to enumerate and execute the provided `action` on. Can not be null. |
| action | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to execute on the `source` collection. Can not be null. |
| lazy | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Using lazy evaluation executes the action once as the `source` is being enumerated, otherwise a full enumeration happens and each element is called on the `action`. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the collection elements. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-ForInternal``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0}-'></a>
### ForInternal\`\`1(source,action) `method`

##### Summary

Internal helper method for the method [For\`\`1](#M-MutatorFX-Coding-GeneralFluentExtensions-For``1-System-Collections-Generic-IEnumerable{``0},System-Action{``0}- 'MutatorFX.Coding.GeneralFluentExtensions.For``1(System.Collections.Generic.IEnumerable{``0},System.Action{``0})'). Used for reducing the number of parameter null checks.
            Note that the input objects in `source` can only be mutated by the provided `action` if `T` is a reference type.

##### Returns

The parameter `source` after invoking `action` with its elements. Evaluated lazily.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') | The collection to enumerate and execute the provided `action` on. Can not be null, but not checked. |
| action | [System.Action{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{``0}') | The action to execute on the `source` collection. Can not be null, but not checked. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the collection elements. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-Pipe``2-``0,System-Func{``0,``1}-'></a>
### Pipe\`\`2(obj,function) `method`

##### Summary

Execute a function with the given object as parameter, and return the result.
            Useful to create fluent APIs and shorten code by closing on the object `obj`.
            Instead of a simple invocation, you can create a closure on the object `obj` and reuse the variable in the `function` scope.
            Note that the input object `obj` can only be mutated by the provided `function` if it is a reference type.

##### Returns

Returns the result of the function invokation of `function` with the parameter `obj`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to call the provided function `function` on. |
| function | [System.Func{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1}') | The function to call with the parameter `obj` and return the resulting value of. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the object `obj`. Has to be a reference type so that structures won't be copied. Should be inferred. |
| TResult | The type of the invokation result of `function`. Should be inferred. |

<a name='M-MutatorFX-Coding-GeneralFluentExtensions-PipeAsync``2-``0,System-Func{``0,System-Threading-Tasks-Task{``1}}-'></a>
### PipeAsync\`\`2(obj,function) `method`

##### Summary

The asynchronous pair of [Pipe\`\`2](#M-MutatorFX-Coding-GeneralFluentExtensions-Pipe``2-``0,System-Func{``0,``1}- 'MutatorFX.Coding.GeneralFluentExtensions.Pipe``2(``0,System.Func{``0,``1})').
            /// Execute and await an asynchronous function with the given object as parameter, and return the result.
            Useful to create fluent APIs and shorten code by closing on the object `obj`.
            Instead of a simple invocation, you can create a closure on the object `obj` and reuse the variable in the `function` scope.
            Note that the input object `obj` can only be mutated by the provided `function` if it is a reference type.

##### Returns

Returns the result of the function invokation of `function` with the parameter `obj`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [\`\`0](#T-``0 '``0') | The object to call the provided function `function` on. |
| function | [System.Func{\`\`0,System.Threading.Tasks.Task{\`\`1}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,System.Threading.Tasks.Task{``1}}') | The function to call with the parameter `obj` and return the resulting value of. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the object `obj`. Has to be a reference type so that structures won't be copied. Should be inferred. |
| TResult | The type of the invokation result of `function`. Should be inferred. |

<a name='T-MutatorFX-Reflection-TypeReflectionExtensions'></a>
## TypeReflectionExtensions `type`

##### Namespace

MutatorFX.Reflection

##### Summary

Globally usable helper extensions, useful when using reflection and [Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') objects.

<a name='M-MutatorFX-Reflection-TypeReflectionExtensions-GetPropertyChain-System-Type,System-String,System-Nullable{System-Reflection-BindingFlags}-'></a>
### GetPropertyChain(type,text,bindingFlags) `method`

##### Summary

Gets the first available property chain that matches the start of the given text. The text should be the concatenation of the property names. 
            In case of multiple matches, the first match is selected by ordering the properties by ascending order of the length of their names.
            In case of no matches are found, an [InvalidOperationException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidOperationException 'System.InvalidOperationException') is thrown.

##### Returns

The property chain in order.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | The type that should contain the properties described by the `text`. |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The string containing the exact names of the chained properties (without separators). |
| bindingFlags | [System.Nullable{System.Reflection.BindingFlags}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Reflection.BindingFlags}') | The  to use when looking for matching properties. |

##### Remarks

This method uses recursion, and calls [GetPropertyChains](#M-MutatorFX-Reflection-TypeReflectionExtensions-GetPropertyChains-System-Type,System-String,System-Nullable{System-Reflection-BindingFlags}- 'MutatorFX.Reflection.TypeReflectionExtensions.GetPropertyChains(System.Type,System.String,System.Nullable{System.Reflection.BindingFlags})') internally.

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
| bindingFlags | [System.Nullable{System.Reflection.BindingFlags}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Reflection.BindingFlags}') | The  to use when looking for matching properties. |
