using MutatorFX.Coding;
using MutatorFX.ExceptionHandling;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MutatorFX.ExcelMutator
{
    /// <summary>
    /// Contains extensions that work on EPPlus' worksheets and workbooks to parse and extract data.
    /// </summary>
    public static class ExcelExtensions
    {
        /// <summary>
        /// Parses an <see cref="ExcelWorkbook"/> object by enumerating it's <see cref="IEnumerable{T}"/> 
        /// properties which have the <see cref="SheetAttribute"/> attribute.
        /// The type parameter of the <see cref="IEnumerable{T}"/> properties are used to parse the values in the
        /// corresponding worksheets.
        /// Returns a newly created and populated model object that represents the parsed data.
        /// </summary>
        /// <typeparam name="T">The result of the parsing. Should contain <see cref="SheetAttribute"/> metadata for it's <see cref="IEnumerable{T}"/> properties.</typeparam>
        /// <param name="workbook">The workbook to parse.</param>
        /// <returns>The populated model object.</returns>
        public static T ParseExcelWorkbook<T>(this ExcelWorkbook workbook)
            where T : new()
        {
            if (workbook == null)
                throw new ArgumentNullException(nameof(workbook));

            var properties = typeof(T).GetProperties()
                .Select(p => (property: p, meta: p.GetCustomAttribute<SheetAttribute>(true)))
                .Where(p => p.meta != null)
                .Select(p => (p.property, p.meta,
                    worksheet: workbook.Worksheets.SingleOrDefault(w => string.Compare(w.Name, p.meta.Name, StringComparison.OrdinalIgnoreCase) == 0)))
                .ToArray();

            var invalidTypeProperties = properties.Where(p => !typeof(List<>).IsAssignableFrom(p.property.PropertyType.GetGenericTypeDefinition()));
            if (invalidTypeProperties.Any())
                throw new InvalidOperationException($"Invalid model. The model's properties annotated with {typeof(SheetAttribute).Name} should be able to recieve values from type List<T>.");

            var missingWorksheets = properties.Where(p => p.worksheet == null && !p.meta.Optional);
            if (missingWorksheets.Any())
                throw new InvalidOperationException($"Invalid format. The following worksheets are missing from the workbook: {string.Join(", ", missingWorksheets.Select(p => p.meta.Name))}.");

            var worksheetParseMethod = typeof(ExcelExtensions).GetMethod(nameof(ParseExcelWorksheet), BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(ExcelWorksheet) }, null);
            return new T().Do(result => properties.Where(p => p.worksheet != null).For(p => p.property.SetValue(result, worksheetParseMethod.MakeGenericMethod(p.property.PropertyType.GenericTypeArguments[0]).Invoke(null, new[] { p.worksheet }))));
        }

        /// <summary>
        /// Creates a resultset of <typeparamref name="T"/> objects from an <see cref="ExcelWorkbook"/> by using the 
        /// <see cref="ColumnAttribute"/>s defined on type <typeparamref name="T"/>'s properties.
        /// </summary>
        /// <typeparam name="T">The type to use as the resulting model, which should contain the parsing metadata.</typeparam>
        /// <param name="workbook">The workbook which should contain the worksheet with name <paramref name="worksheetName"/> to parse.</param>
        /// <param name="worksheetName">The name of the worksheet to parse. It should match the structure of the type <typeparamref name="T"/>.</param>
        /// <returns>The resultset of <typeparamref name="T"/> objects, as constructed from the metadata contained 
        /// in the type's properties' <see cref="ColumnAttribute"/> attributes.</returns>
        public static List<T> ParseExcelWorksheet<T>(this ExcelWorkbook workbook, string worksheetName)
            where T : RowModelBase, new()
             => ParseExcelWorksheet<T>(workbook.Worksheets[worksheetName]);

        /// <summary>
        /// Creates a resultset of <typeparamref name="T"/> objects from an <see cref="ExcelWorkbook"/> by using the 
        /// <see cref="ColumnAttribute"/>s defined on type <typeparamref name="T"/>'s properties.
        /// </summary>
        /// <typeparam name="T">The type to use as the resulting model, which should contain the parsing metadata.</typeparam>
        /// <param name="worksheet">The worksheet to parse. It should match the structure of the type <typeparamref name="T"/>.</param>
        /// <returns>The resultset of <typeparamref name="T"/> objects, as constructed from the metadata contained 
        /// in the type's properties' <see cref="ColumnAttribute"/> attributes.</returns>
        public static List<T> ParseExcelWorksheet<T>(this ExcelWorksheet worksheet)
            where T : RowModelBase, new()
        {
            if (worksheet == null)
                throw new ArgumentNullException(nameof(worksheet));

            var properties = typeof(T).GetProperties()
                .Select(p => (property: p, meta: p.GetCustomAttribute<ColumnAttribute>(true)))
                .Where(p => p.meta != null)
                .Select(p => (p.property, p.meta,
                    column: Enumerable.Range(1, worksheet.Dimension.Columns).SingleOrDefault(c => string.Compare(worksheet.Cells[1, c].Text, p.meta.Name, StringComparison.OrdinalIgnoreCase) == 0)))
                .ToArray();

            var missingProperties = properties.Where(p => p.column == 0 && !p.meta.Optional);
            if (missingProperties.Any())
                throw new InvalidOperationException($"Invalid format. The following values are missing from the worksheet: {string.Join(", ", missingProperties.Select(p => p.meta.Name))}.");

            return Enumerable.Range(1, worksheet.Dimension.Rows - 1).Select(r =>
                new T { RowNumber = r + 1 }.Do(parsedRowData => properties.Where(p => p.column != 0).For(p =>
                {
                    try
                    {
                        p.property.SetValue(parsedRowData, p.meta.Parse(worksheet.Cells[r + 1, p.column].Value, p.property));
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("An error occored during the parsing of the worksheet.", ex).WithData(new { Row = r + 1, Column = p.column, Worksheet = worksheet.Name });
                    }
                }))).ToList();
        }
    }
}
