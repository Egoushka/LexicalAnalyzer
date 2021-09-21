using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using LexicalAnalyzer.Models;

namespace LexicalAnalyzer.Tools
{
    public static class StringTools
    {
        public static string ReplaceWhitespace(this string input, string replacement)
        {
            Regex sWhitespace = new Regex(@"\s+");

            return sWhitespace.Replace(input, replacement);
        }

        public static TokenType IndicateTokenType(this string lexeme)
        {
            if (lexeme == null)
                throw new NullReferenceException();
            
            var lexemeToEquals = lexeme.ToLower();
            
            if (AnalyzerConstants.Keywords.Any(item => item.Equals(lexemeToEquals)))
                return TokenType.Keyword;
            else if (AnalyzerConstants.LogicSymbols.Any(item => item.Equals(lexemeToEquals)))
                return TokenType.Relop; 
            else if (int.TryParse(lexemeToEquals, out int i))
                return TokenType.Num;
            else if (lexemeToEquals.StartsWith('\''))
                return TokenType.Literal;
            return TokenType.Id;
        }
    }
}
