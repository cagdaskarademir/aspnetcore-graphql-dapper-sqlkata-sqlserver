using System.Linq;
using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;

namespace CK.Tutorial.GraphQlApi.Web.Extensions
{
    public static class GraphQlExtension
    {
        public static string[] GetMainSelectedFields(this ResolveFieldContext<object> context)
        {
            return context.FieldAst.GetSelectedFields();
        }

        public static string[] GetMainSelectedFields<T>(this ResolveFieldContext<T> context)
        {
            return context.FieldAst.GetSelectedFields();
        }

        public static string[] GetMainSelectedFields<T>(this ResolveFieldContext context)
        {
            return context.FieldAst.GetSelectedFields();
        }

        private static string[] GetSelectedFields(this IHaveSelectionSet field)
        {
            var fields = field
                .SelectionSet
                .Selections
                .OfType<Field>()
                .Where(p => !p.SelectionSet.Selections.Any())
                .Select(p => p.Name.ToPascalCase()).ToArray();

            return fields;
        }
    }
}