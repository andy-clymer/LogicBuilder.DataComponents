﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LogicBuilder.Expressions.Utils.ExpressionBuilder.Lambda
{
    public abstract class FilterMethodOperatorBase
    {
        public FilterMethodOperatorBase(IDictionary<string, ParameterExpression> parameters, IExpressionPart sourceOperand, IExpressionPart filterBody, string filterParameterName)
        {
            SourceOperand = sourceOperand;
            FilterBody = filterBody;
            Parameters = parameters;
            FilterParameterName = filterParameterName;
        }

        public FilterMethodOperatorBase(IExpressionPart sourceOperand)
        {
            SourceOperand = sourceOperand;
        }

        public IExpressionPart SourceOperand { get; }
        public IExpressionPart FilterBody { get; }
        public IDictionary<string, ParameterExpression> Parameters { get; }
        public string FilterParameterName { get; }

        public Expression Build() => Build(SourceOperand.Build());

        protected abstract Expression Build(Expression operandExpression);

        protected Expression[] GetParameters(Expression operandExpression)
        {
            if (FilterBody == null)
                return new Expression[0];

            return new Expression[]
            {
                GetFilterLambdaOperator(operandExpression.GetUnderlyingElementType()).Build()
            };
        }

        protected FilterLambdaOperator GetFilterLambdaOperator(Type elementType) 
            => new FilterLambdaOperator
            (
                Parameters,
                FilterBody,
                elementType,
                FilterParameterName
            );
    }
}
