﻿namespace LogicBuilder.Expressions.Utils.FilterBuilder.Logical
{
    public class LessThanOrEqualsBinaryOperator : BinaryOperator
    {
        public LessThanOrEqualsBinaryOperator(IExpressionPart left, IExpressionPart right) : base(left, right)
        {
        }

        public override FilterFunction Operator => FilterFunction.le;
    }
}
