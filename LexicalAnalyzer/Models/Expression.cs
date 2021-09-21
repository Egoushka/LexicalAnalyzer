using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using LexicalAnalyzer.Tools;
using Newtonsoft.Json;

namespace LexicalAnalyzer.Models
{
    public class Expression
    {
        public int UniqueTokensCount { get; set; } = default;
        private string Value { get; set; }
        private string ValueWithNoWhiteSpaces { get; }
        public List<Token> Tokens { get; set; } = new();
        private int LengthOfValueWithNoSpaces { get; set; } 
        
        public Expression(string value)
        {
            Value = value;
            ValueWithNoWhiteSpaces = value.ReplaceWhitespace("");
            LengthOfValueWithNoSpaces = ValueWithNoWhiteSpaces.Length;
        }
      
        public void PickOutLexemes()
        {
            int index = 0;
            
            while (PickOutNextLexem(ref index) != -1)
            {
                ++index;
            }

            Console.WriteLine(JsonConvert.SerializeObject(Tokens, Formatting.Indented));
        }

        private int PickOutNextLexem(ref int index)
        {
            int nextLexem = SkipAllSeparators(index);
            
            string lexeme = PickOutLexeme(ref nextLexem);
            
            var lexemePositionInString = Tokens
                .FirstOrDefault(item => item.Lexeme.Equals(lexeme))?
                .PositionInString?? ++UniqueTokensCount;
            
            AddNewToken(lexeme, lexemePositionInString, nextLexem - index);
            
            if(nextLexem >= Value.Length)
                return -1;
            
            index = nextLexem;
            
            return nextLexem;
        }

        private int SkipAllSeparators(int index)
        {
            while (index < Value.Length && AnalyzerConstants.Separators.Any(item => Value[index] == item))
            {
                ++index;
            }

            return index;
        }
        private string PickOutLexeme(ref int nextLexemIndex)
        {
            StringBuilder builder = new StringBuilder();
            
            bool flag = false;
            int i = nextLexemIndex;

            for (; i < Value.Length; i++)
            {
                if (AnalyzerConstants.Separators.Any(item => Value[i] == item) && flag == false)
                {
                    break;
                }

                if (AnalyzerConstants.LiteralSeparators.Any(item => Value[i] == item))
                {
                    flag = !flag;
                }

                builder.Append(Value[i]);
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