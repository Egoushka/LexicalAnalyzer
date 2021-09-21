using System;
using System.Linq;

namespace LexicalAnalyzer.Models
{
    public class Token
    {
        public string TokenType { get; init; }
        
        public string Lexeme { get; init; }
        
        public int StartPosition { get; init; }
        
        public int Length { get; init; }
        
        public int PositionInString { get; init; }

        public Token(){}
        public Token(TokenType tokenType, string lexeme, int startPosition, int length, int positionInString)
        {
            TokenType = tokenType.ToString();
            Lexeme = lexeme;
            StartPosition = startPosition;
            Length = length;
            PositionInString = positionInString;
        }

       
    }
}