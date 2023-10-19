namespace Minsk.CodeAnalysis;

enum SyntaxKind
{
    NumberToken,
    WhitespaceToken,
    PlusToken,
    MinusToken,
    StarToken,
    SlashToken,
    OpenParenthesisToken,
    CloseParenthesisToken,
    EndOfFileToken,
    BadToken,
    NumberExpression,
    BinaryExpression,
    ParenthesisedExpression
}