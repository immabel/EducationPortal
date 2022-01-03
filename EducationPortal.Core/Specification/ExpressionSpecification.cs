namespace EducationPortal.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class ExpressionSpecification<T>
        where T : class
    {
        public ExpressionSpecification(
            Expression<Func<T, bool>> expression,
            List<Expression<Func<T, object>>> includes = default)
        {
            this.Expression = expression;
            this.Includes = includes;
        }

        public Expression<Func<T, bool>> Expression { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; }
    }
}