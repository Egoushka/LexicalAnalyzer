using System;
using System.Text;
using LexicalAnalyzer.Constants;
using LexicalAnalyzer.Models;

namespace LexicalAnalyzer.Services.IdCreationServices
{
    public class Id4CreationService : IdCreationService
    {
        public string MakeId()
        {
            string result = AddStartSymbol() + AddSymbols(20);
            return result;
        }
        private char AddStartSymbol()
        {
            Random random = new();
            return IdTokenConstants.StartSymbolsForId4[random.Next(0, IdTokenConstants.StartSymbolsForId4.Length)];
        }
        private string AddSymbols(int count)
        {
            StringBuilder builder = new();
            Random random = new();
            for (int i = 0; i < count; i++)
            {
                builder.Append(IdTokenConstants.SymbolsForId4[random.Next(0, IdTokenConstants.SymbolsForId4.Length)]);
            }
            return builder.ToString();
        }
    }
}