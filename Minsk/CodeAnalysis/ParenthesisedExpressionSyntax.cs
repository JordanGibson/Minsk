namespace Minsk.CodeAnalysis;

public sealed class ParenthesisedExpressionSyntax : ExpressionSyntax
{
    public SyntaxToken OpenParenthesisToken { get; }
    public ExpressionSyntax Expression { get; }
    public SyntaxToken CloseParenthesisToken { get; }

    public ParenthesisedExpressionSyntax(SyntaxToken openParenthesisToken, ExpressionSyntax expression, SyntaxToken closeParenthesisToken)
    {
        OpenParenthesisToken = openParenthesisToken;
        Expression = expression;
        CloseParenthesisToken = closeParenthesisToken;
    }

    public override SyntaxKind Kind => SyntaxKind.ParenthesisedExpression;
    public override IEnumerable<SyntaxNode> GetChildren()
    {
        yield return OpenParenthesisToken;
        yield return Expression;
        yield return CloseParenthesisToken;
    }
}