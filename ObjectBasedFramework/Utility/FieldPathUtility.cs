using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClussPro.ObjectBasedFramework.Utility
{
    public static class FieldPathUtility
    {
        public static List<string> CreateFieldPathsAsList<TDataObject>(Expression<Func<TDataObject, List<object>>> expression)
        {
            if (!(expression.Body is ListInitExpression listInitExpression))
            {
                return null;
            }

            List<string> fieldPaths = new List<string>();
            foreach (Expression elementInitArgument in listInitExpression.Initializers.OfType<ElementInit>().SelectMany(ei => ei.Arguments))
            {
                StringBuilder fieldBuilder = new StringBuilder();
                DrillToRoot(elementInitArgument, fieldBuilder);
                fieldPaths.Add(fieldBuilder.ToString(0, fieldBuilder.Length - 1));
            }

            return fieldPaths;
        }

        public static string CreateFieldPaths<TDataObject>(Expression<Func<TDataObject, List<object>>> expression)
        {
            List<string> fieldPaths = CreateFieldPathsAsList<TDataObject>(expression);
            StringBuilder fieldPathBuilder = new StringBuilder(";");
            foreach(string fieldPath in fieldPaths)
            {
                fieldPathBuilder.Append(fieldPath + ";");
            }

            return fieldPathBuilder.ToString().Substring(1);
        }

        private static void DrillToRoot(Expression expression, StringBuilder fieldBuilder)
        {
            MemberExpression memberExpression = null;
            if (expression is UnaryExpression unaryExpression)
            {
                if (!(unaryExpression.Operand is MemberExpression))
                {
                    return;
                }

                memberExpression = (MemberExpression)unaryExpression.Operand;
            }

            if (expression is MemberExpression)
            {
                memberExpression = (MemberExpression)expression;
            }

            if (memberExpression == null)
            {
                return;
            }

            fieldBuilder.Insert(0, memberExpression.Member.Name + ".");
            DrillToRoot(memberExpression.Expression, fieldBuilder);
        }
    }
}
