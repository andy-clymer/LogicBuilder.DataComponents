﻿using System;
using System.Linq.Expressions;

namespace LogicBuilder.Expressions.Utils.FilterBuilder.Operand
{
    public class ConvertOperand : IExpressionPart
    {
        public ConvertOperand(Type type, IExpressionPart sourceOperand)
        {
            Type = type;
            SourceOperand = sourceOperand;
        }

        public Type Type { get; }
        public IExpressionPart SourceOperand { get; }

        public Expression Build()
        {
            try
            {
                return Expression.Convert(SourceOperand.Build(), Type);
            }
            catch (InvalidOperationException)
            {
                return Expression.Constant(null);
            }
        }
    }
}
