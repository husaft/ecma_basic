﻿using ECMABasic.Core.Statements;

namespace ECMABasic.Core.Parsers
{
	public class IfThenStatementParser : StatementParser
	{
		public override IStatement Parse(ComplexTokenReader reader, int? lineNumber = null)
		{
			if (reader.Next(TokenType.Word, false, @"IF") == null)
			{
				return null;
			}

			ProcessSpace(reader, true);

			var conditionExpr = ParseExpression(reader, lineNumber, true);
			if (conditionExpr == null)
			{
				throw ExceptionFactory.ExpectedConditionalExpression(lineNumber);
			}

			ProcessSpace(reader, true);

			reader.Next(TokenType.Word, true, @"THEN");

			ProcessSpace(reader, true);

			var lineNumberExpr = ParseExpression(reader, lineNumber, true);
			if (lineNumberExpr == null)
			{
				throw ExceptionFactory.ExpectedNumericExpression(lineNumber);
			}

			return new IfThenStatement(conditionExpr, lineNumberExpr);
		}
	}
}
