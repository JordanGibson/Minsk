﻿namespace Minsk.CodeAnalysis;

public sealed class LiteralExpressionSyntax : ExpressionSyntax
{
    public SyntaxToken LiteralToken { get; }

    public LiteralExpressionSyntax(SyntaxToken literalToken)
    {
        LiteralToken = literalToken;
    }

    public override SyntaxKind Kind => SyntaxKind.NumberExpression;
    public override IEnumerable<SyntaxNode> GetChildren()
    {
        yield return LiteralToken;
    }
}