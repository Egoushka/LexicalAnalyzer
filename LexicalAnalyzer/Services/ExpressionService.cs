using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LexicalAnalyzer.Constants;
using LexicalAnalyzer.Models;
using LexicalAnalyzer.Tools;

namespace LexicalAnalyzer.Services
{
    public class ExpressionService
    {
        public List<Token> Tokens { get; set; }
        public int UniqueTokensCount { get; set; }
        private string Query { get; set; }
        private string ValueWithNoWhiteSpaces { get; set; }

        public void ProcessQuery(string query)
        {
            Query = query;
            
            ValueWithNoWhiteSpaces = query.ReplaceWhitespace("");

            Tokens = new List<Token>();
            UniqueTokensCount = default;
            
            PickOutLexemes();
        }
        private void PickOutLexemes()
        {
            int index = 0;
            
            while (PickOutNextLexem(ref index) != -1)
            {
                ++index;
            }
        }

        private int PickOutNextLexem(ref int index)
        {
            int nextLexem = SkipAllSeparators(index);
            
            string lexeme = PickOutLexeme(ref nextLexem);
            
            var lexemePositionInString = Tokens
                .FirstOrDefault(item => item.Lexeme.Equals(lexeme))?
                .PositionInString?? ++UniqueTokensCount;
            
            AddNewToken(lexeme, lexemePositionInString, nextLexem - index);
            
            if(nextLexem >= Query.Length)
                return -1;
            
            index = nextLexem;
            
            return nextLexem;
        }

        private int SkipAllSeparators(int index)
        {
            while (index < Query.Length && AnalyzerConstants.Separators.Any(item => Query[index] == item))
            {
                ++index;
            }

            return index;
        }
        private string PickOutLexeme(ref int nextLexemIndex)
        {
            StringBuilder builder = new();
            
            bool flag = false;
            int i = nextLexemIndex;

            for (; i < Query.Length; i++)
            {
                if (AnalyzerConstants.Separators.Any(item => Query[i] == item) && flag == false)
                {
                    break;
                }

                if (AnalyzerConstants.LiteralSeparators.Any(item => Query[i] == item))
                {
                    flag = !flag;
                }

                builder.Append(Query[i]);
            }

            nextLexemIndex = i;
            return builder.ToString();
        }
        private bool AddNewToken(string lexeme, int? positionInString, int length)
        {
            Tokens.Add(
                new Token
                {
                    TokenType = lexeme.IndicateTokenType().ToString(),
                    Lexeme = lexeme,
                    PositionInString = positionInString ?? UniqueTokensCount,
                    Length = length,
                    StartPosition = ValueWithNoWhiteSpaces.IndexOf(lexeme.ReplaceWhitespace(""), StringComparison.Ordinal)
                });
            return true;
        }
    }
}