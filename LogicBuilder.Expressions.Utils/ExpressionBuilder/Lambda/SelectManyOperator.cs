﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LogicBuilder.Expressions.Utils.ExpressionBuilder.Lambda
{
    public class SelectManyOperator : SelectorMethodOperatorBase, IExpressionPart
    {
        public SelectManyOperator(IDictionary<string, ParameterExpression> parameters, IExpressionPart sourceOperand, IExpressionPart selectorBody, string selectorParameterName) : base(parameters, sourceOperand, selectorBody, selectorParameterName)
        {
        }

        protected override Expression Build(Expression operandExpression)
            => operandExpression.GetSelectManyCall(GetSelector(operandExpression));

        protected override IExpressionPart GetLambdaOperator(Type sourceElementType)
            => new IEnumerableSelectorLambdaOperator
            (
                Parameters,
                SelectorBody,
                sourceElementType,
                SelectorParameterName
            );
    }
}
