<a name='assembly'></a>
# MutatorFX.ExcelMutator.Core

## Contents

- [ColumnAttribute](#T-MutatorFX-ExcelMutator-ColumnAttribute 'MutatorFX.ExcelMutator.ColumnAttribute')
  - [#ctor(name)](#M-MutatorFX-ExcelMutator-ColumnAttribute-#ctor-System-String- 'MutatorFX.ExcelMutator.ColumnAttribute.#ctor(System.String)')
  - [Name](#P-MutatorFX-ExcelMutator-ColumnAttribute-Name 'MutatorFX.ExcelMutator.ColumnAttribute.Name')
  - [Optional](#P-MutatorFX-ExcelMutator-ColumnAttribute-Optional 'MutatorFX.ExcelMutator.ColumnAttribute.Optional')
  - [OutputOrder](#P-MutatorFX-ExcelMutator-ColumnAttribute-OutputOrder 'MutatorFX.ExcelMutator.ColumnAttribute.OutputOrder')
  - [ParserType](#P-MutatorFX-ExcelMutator-ColumnAttribute-ParserType 'MutatorFX.ExcelMutator.ColumnAttribute.ParserType')
  - [SplitSeparators](#P-MutatorFX-ExcelMutator-ColumnAttribute-SplitSeparators 'MutatorFX.ExcelMutator.ColumnAttribute.SplitSeparators')
  - [StringSplitOptions](#P-MutatorFX-ExcelMutator-ColumnAttribute-StringSplitOptions 'MutatorFX.ExcelMutator.ColumnAttribute.StringSplitOptions')
  - [Trim](#P-MutatorFX-ExcelMutator-ColumnAttribute-Trim 'MutatorFX.ExcelMutator.ColumnAttribute.Trim')
  - [Parse(value,property)](#M-MutatorFX-ExcelMutator-ColumnAttribute-Parse-System-Object,System-Reflection-PropertyInfo- 'MutatorFX.ExcelMutator.ColumnAttribute.Parse(System.Object,System.Reflection.PropertyInfo)')
- [ExcelExtensions](#T-MutatorFX-ExcelMutator-ExcelExtensions 'MutatorFX.ExcelMutator.ExcelExtensions')
  - [ParseExcelWorkbook\`\`1(workbook)](#M-MutatorFX-ExcelMutator-ExcelExtensions-ParseExcelWorkbook``1-OfficeOpenXml-ExcelWorkbook- 'MutatorFX.ExcelMutator.ExcelExtensions.ParseExcelWorkbook``1(OfficeOpenXml.ExcelWorkbook)')
  - [ParseExcelWorksheet\`\`1(workbook,worksheetName)](#M-MutatorFX-ExcelMutator-ExcelExtensions-ParseExcelWorksheet``1-OfficeOpenXml-ExcelWorkbook,System-String- 'MutatorFX.ExcelMutator.ExcelExtensions.ParseExcelWorksheet``1(OfficeOpenXml.ExcelWorkbook,System.String)')
  - [ParseExcelWorksheet\`\`1(worksheet)](#M-MutatorFX-ExcelMutator-ExcelExtensions-ParseExcelWorksheet``1-OfficeOpenXml-ExcelWorksheet- 'MutatorFX.ExcelMutator.ExcelExtensions.ParseExcelWorksheet``1(OfficeOpenXml.ExcelWorksheet)')
- [IParser](#T-MutatorFX-ExcelMutator-IParser 'MutatorFX.ExcelMutator.IParser')
  - [Parse(value,targetProperty)](#M-MutatorFX-ExcelMutator-IParser-Parse-System-Object,System-Reflection-PropertyInfo- 'MutatorFX.ExcelMutator.IParser.Parse(System.Object,System.Reflection.PropertyInfo)')
- [RowModelBase](#T-MutatorFX-ExcelMutator-RowModelBase 'MutatorFX.ExcelMutator.RowModelBase')
  - [RowNumber](#P-MutatorFX-ExcelMutator-RowModelBase-RowNumber 'MutatorFX.ExcelMutator.RowModelBase.RowNumber')
  - [ToString()](#M-MutatorFX-ExcelMutator-RowModelBase-ToString 'MutatorFX.ExcelMutator.RowModelBase.ToString')
- [SheetAttribute](#T-MutatorFX-ExcelMutator-SheetAttribute 'MutatorFX.ExcelMutator.SheetAttribute')
  - [#ctor(name)](#M-MutatorFX-ExcelMutator-SheetAttribute-#ctor-System-String- 'MutatorFX.ExcelMutator.SheetAttribute.#ctor(System.String)')
  - [Name](#P-MutatorFX-ExcelMutator-SheetAttribute-Name 'MutatorFX.ExcelMutator.SheetAttribute.Name')
  - [Optional](#P-MutatorFX-ExcelMutator-SheetAttribute-Optional 'MutatorFX.ExcelMutator.SheetAttribute.Optional')
  - [OutputOrder](#P-MutatorFX-ExcelMutator-SheetAttribute-OutputOrder 'MutatorFX.ExcelMutator.SheetAttribute.OutputOrder')

<a name='T-MutatorFX-ExcelMutator-ColumnAttribute'></a>
## ColumnAttribute `type`

##### Namespace

MutatorFX.ExcelMutator

##### Summary

Use this attribute to annotate the properties in a [RowModelBase](#T-MutatorFX-ExcelMutator-RowModelBase 'MutatorFX.ExcelMutator.RowModelBase')class 
with metadata for the parsing and extraction of cell values.

<a name='M-MutatorFX-ExcelMutator-ColumnAttribute-#ctor-System-String-'></a>
### #ctor(name) `constructor`

##### Summary

Use this attribute to annotate the properties in a [RowModelBase](#T-MutatorFX-ExcelMutator-RowModelBase 'MutatorFX.ExcelMutator.RowModelBase')class 
with metadata for the parsing and extraction of cell values.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the header row to match the cell contents againts. Not case sensitive. |

<a name='P-MutatorFX-ExcelMutator-ColumnAttribute-Name'></a>
### Name `property`

##### Summary

The name of the header row to match the cell contents againts. Not case sensitive.

<a name='P-MutatorFX-ExcelMutator-ColumnAttribute-Optional'></a>
### Optional `property`

##### Summary

Indicates whether the omission of the column can be overlooked. 
Defaults to false.

<a name='P-MutatorFX-ExcelMutator-ColumnAttribute-OutputOrder'></a>
### OutputOrder `property`

##### Summary

The order value to use when extracting data from a [RowModelBase](#T-MutatorFX-ExcelMutator-RowModelBase 'MutatorFX.ExcelMutator.RowModelBase')datasource.

<a name='P-MutatorFX-ExcelMutator-ColumnAttribute-ParserType'></a>
### ParserType `property`

##### Summary

The type of IParser to use. Will be instantiated with [CreateInstance](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Activator.CreateInstance 'System.Activator.CreateInstance(System.Type)'). 
The resulting object will be cached and reused. The default uses the attribute itself to parse.

<a name='P-MutatorFX-ExcelMutator-ColumnAttribute-SplitSeparators'></a>
### SplitSeparators `property`

##### Summary

In case of strings and string collections, indicates the separator values to use.
Default is a single comma: ","

<a name='P-MutatorFX-ExcelMutator-ColumnAttribute-StringSplitOptions'></a>
### StringSplitOptions `property`

##### Summary

In case of strings and string collections, indicates whether the splitting options should remove empty entries.
Defaults to [None](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.StringSplitOptions.None 'System.StringSplitOptions.None')

<a name='P-MutatorFX-ExcelMutator-ColumnAttribute-Trim'></a>
### Trim `property`

##### Summary

In case of strings and string collections, indicates whether to trim the string value or not.
Defaults to true.

<a name='M-MutatorFX-ExcelMutator-ColumnAttribute-Parse-System-Object,System-Reflection-PropertyInfo-'></a>
### Parse(value,property) `method`

##### Summary

The default parser will try and parse a single value from a cell with regards to the target property.
Enum parsing matches the names or [Name](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ComponentModel.DataAnnotations.DisplayAttribute.Name 'System.ComponentModel.DataAnnotations.DisplayAttribute.Name')values case insensitively.
If the target property is assignable from a string [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1'), splitting occurs.
If you want more control over parsing, subclass this attribute and override the default functionality.

##### Returns

The parsed value to set to the target property of the row object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value to parse from the cell. |
| property | [System.Reflection.PropertyInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.PropertyInfo 'System.Reflection.PropertyInfo') | The type of the target property to populate. |

<a name='T-MutatorFX-ExcelMutator-ExcelExtensions'></a>
## ExcelExtensions `type`

##### Namespace

MutatorFX.ExcelMutator

##### Summary

Contains extensions that work on EPPlus' worksheets and workbooks to parse and extract data.

<a name='M-MutatorFX-ExcelMutator-ExcelExtensions-ParseExcelWorkbook``1-OfficeOpenXml-ExcelWorkbook-'></a>
### ParseExcelWorkbook\`\`1(workbook) `method`

##### Summary

Parses an [ExcelWorkbook](#T-OfficeOpenXml-ExcelWorkbook 'OfficeOpenXml.ExcelWorkbook')object by enumerating it's [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')
properties which have the [SheetAttribute](#T-MutatorFX-ExcelMutator-SheetAttribute 'MutatorFX.ExcelMutator.SheetAttribute')attribute.
The type parameter of the [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')properties are used to parse the values in the
corresponding worksheets.
Returns a newly created and populated model object that represents the parsed data.

##### Returns

The populated model object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workbook | [OfficeOpenXml.ExcelWorkbook](#T-OfficeOpenXml-ExcelWorkbook 'OfficeOpenXml.ExcelWorkbook') | The workbook to parse. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The result of the parsing. Should contain [SheetAttribute](#T-MutatorFX-ExcelMutator-SheetAttribute 'MutatorFX.ExcelMutator.SheetAttribute')metadata for it's [IEnumerable\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable`1 'System.Collections.Generic.IEnumerable`1')properties. |

<a name='M-MutatorFX-ExcelMutator-ExcelExtensions-ParseExcelWorksheet``1-OfficeOpenXml-ExcelWorkbook,System-String-'></a>
### ParseExcelWorksheet\`\`1(workbook,worksheetName) `method`

##### Summary

Creates a resultset of `T`objects from an [ExcelWorkbook](#T-OfficeOpenXml-ExcelWorkbook 'OfficeOpenXml.ExcelWorkbook')by using the 
[ColumnAttribute](#T-MutatorFX-ExcelMutator-ColumnAttribute 'MutatorFX.ExcelMutator.ColumnAttribute')s defined on type `T`'s properties.

##### Returns

The resultset of `T`objects, as constructed from the metadata contained 
in the type's properties' [ColumnAttribute](#T-MutatorFX-ExcelMutator-ColumnAttribute 'MutatorFX.ExcelMutator.ColumnAttribute')attributes.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| workbook | [OfficeOpenXml.ExcelWorkbook](#T-OfficeOpenXml-ExcelWorkbook 'OfficeOpenXml.ExcelWorkbook') | The workbook which should contain the worksheet with name `worksheetName`to parse. |
| worksheetName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the worksheet to parse. It should match the structure of the type `T`. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type to use as the resulting model, which should contain the parsing metadata. |

<a name='M-MutatorFX-ExcelMutator-ExcelExtensions-ParseExcelWorksheet``1-OfficeOpenXml-ExcelWorksheet-'></a>
### ParseExcelWorksheet\`\`1(worksheet) `method`

##### Summary

Creates a resultset of `T`objects from an [ExcelWorkbook](#T-OfficeOpenXml-ExcelWorkbook 'OfficeOpenXml.ExcelWorkbook')by using the 
[ColumnAttribute](#T-MutatorFX-ExcelMutator-ColumnAttribute 'MutatorFX.ExcelMutator.ColumnAttribute')s defined on type `T`'s properties.

##### Returns

The resultset of `T`objects, as constructed from the metadata contained 
in the type's properties' [ColumnAttribute](#T-MutatorFX-ExcelMutator-ColumnAttribute 'MutatorFX.ExcelMutator.ColumnAttribute')attributes.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| worksheet | [OfficeOpenXml.ExcelWorksheet](#T-OfficeOpenXml-ExcelWorksheet 'OfficeOpenXml.ExcelWorksheet') | The worksheet to parse. It should match the structure of the type `T`. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type to use as the resulting model, which should contain the parsing metadata. |

<a name='T-MutatorFX-ExcelMutator-IParser'></a>
## IParser `type`

##### Namespace

MutatorFX.ExcelMutator

##### Summary

Represents a parser that can parse a single value to a property of a cell.

<a name='M-MutatorFX-ExcelMutator-IParser-Parse-System-Object,System-Reflection-PropertyInfo-'></a>
### Parse(value,targetProperty) `method`

##### Summary

Parse an object from the datasouce's single cell, with regards to the target property to populate.

##### Returns

The parsed value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The value in the datasource's cell. |
| targetProperty | [System.Reflection.PropertyInfo](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Reflection.PropertyInfo 'System.Reflection.PropertyInfo') | The property to populate. |

<a name='T-MutatorFX-ExcelMutator-RowModelBase'></a>
## RowModelBase `type`

##### Namespace

MutatorFX.ExcelMutator

##### Summary

The base class used in row parsing. Holds the number of the row which it is constructed from.

<a name='P-MutatorFX-ExcelMutator-RowModelBase-RowNumber'></a>
### RowNumber `property`

##### Summary

The source number of the row in the worksheet the model is constructed from.

<a name='M-MutatorFX-ExcelMutator-RowModelBase-ToString'></a>
### ToString() `method`

##### Summary

Get the friendly formatted string name of the model, ordered by the corresponding [OutputOrder](#P-MutatorFX-ExcelMutator-ColumnAttribute-OutputOrder 'MutatorFX.ExcelMutator.ColumnAttribute.OutputOrder')property.

##### Returns



##### Parameters

This method has no parameters.

<a name='T-MutatorFX-ExcelMutator-SheetAttribute'></a>
## SheetAttribute `type`

##### Namespace

MutatorFX.ExcelMutator

##### Summary

Use this attribute to annotate the properties of a model type with metadata that is used
to identify the worksheets to parse for model extraction.

<a name='M-MutatorFX-ExcelMutator-SheetAttribute-#ctor-System-String-'></a>
### #ctor(name) `constructor`

##### Summary

Use this attribute to annotate the properties of a model type with metadata that is used
to identify the worksheets to parse for model extraction.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the worksheet to use. |

<a name='P-MutatorFX-ExcelMutator-SheetAttribute-Name'></a>
### Name `property`

##### Summary

The name of the worksheet to use.

<a name='P-MutatorFX-ExcelMutator-SheetAttribute-Optional'></a>
### Optional `property`

##### Summary

Indicates whether the omission of the worksheet can be overlooked. 
Defaults to false.

<a name='P-MutatorFX-ExcelMutator-SheetAttribute-OutputOrder'></a>
### OutputOrder `property`

##### Summary

The order value to use when extracting data from a datasource.
