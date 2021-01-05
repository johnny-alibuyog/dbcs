using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace CooperativeSystem.Service.Utilities
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }

    //public static class PredicateBuilder
    //{

    //    public static Expression<Func<T, bool>> True<T>()
    //    {
    //        return Expression.Lambda<Func<T, bool>>(Expression.Constant(true) < Expression.Parameter(typeof(T)));
    //    }

    //    public static Expression<Func<T, bool>> False<T>()
    //    {
    //        return Expression.Lambda<Func<T, bool>>(Expression.Constant(false), Expression.Parameter(typeof(T)));
    //    }

    //    public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> self, Expression<Func<T, bool>> expression)
    //    {
    //        return Combine(self, expression, Expression.OrElse);
    //    }

    //    public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> self, Expression<Func<T, bool>> expression)
    //    {
    //        return Combine(self, expression, Expression.AndAlso);
    //    }

    //    static Expression<Func<T, bool>> Combine<T>(Expression<Func<T, bool>> self, Expression<Func<T, bool>> expression, Func<Expression, Expression, Expression> selector)
    //    {
    //        CheckSelfAndExpression(self, expression);

    //        var parameter = CreateParameterFrom(self);

    //        return Expression.Lambda<Func<T, bool>>(
    //        selector(
    //        RewriteLambdaBody(self, parameter),
    //        RewriteLambdaBody(expression, parameter)),
    //        parameter);
    //    }

    //    private static Expression RewriteLambdaBody(LambdaExpression expression, ParameterExpression parameter)
    //    {
    //        return new ParameterRewriter(expression.Parameters[0], parameter).Visit(expression.Body);
    //    }

    //    private class ParameterRewriter : ExpressionVisitor
    //    {

    //        readonly ParameterExpression candidate;
    //        readonly ParameterExpression replacement;

    //        public ParameterRewriter(ParameterExpression candidate, ParameterExpression replacement)
    //        {
    //            this.candidate = candidate;
    //            this.replacement = replacement;
    //        }

    //        protected override Expression VisitParameter(ParameterExpression expression)
    //        {
    //            return ReferenceEquals(expression, candidate) ? replacement : expression;
    //        }
    //    }

    //    private static ParameterExpression CreateParameterFrom<T>(Expression<Func<T, bool>> left)
    //    {
    //        var template = left.Parameters[0];

    //        return Expression.Parameter(template.Type, template.Name);
    //    }

    //    private static void CheckSelfAndExpression<T>(Expression<Func<T, bool>> self, Expression<Func<T, bool>> expression)
    //    {
    //        if (self == null)
    //            throw new ArgumentNullException("self");
    //        if (expression == null)
    //            throw new ArgumentNullException("expression");
    //    }
    //}
}
