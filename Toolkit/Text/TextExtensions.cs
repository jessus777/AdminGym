using CaseExtensions;

namespace Toolkit.Text;
public static class TextExtensions
{
    public static string ApplyConvention(this string str, CaseConvention? convention)
        => convention switch
        {
            CaseConvention.LowerCase => str.ToLower(),
            CaseConvention.UpperCase => str.ToUpper(),
            CaseConvention.CamelCase => str.ToCamelCase(),
            CaseConvention.PascalCase => str.ToPascalCase(),
            CaseConvention.LowerKebabCase => str.ToKebabCase(),
            CaseConvention.UpperKebabCase => str.ToKebabCase().ToUpper(),
            CaseConvention.LowerSnakeCase => str.ToSnakeCase(),
            CaseConvention.UpperSnakeCase => str.ToSnakeCase().ToUpper(),
            CaseConvention.TrainCase => str.ToTrainCase(),
            _ => str
        };
}
