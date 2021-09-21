using System;
using System.Text;
using LexicalAnalyzer.Constants;
using LexicalAnalyzer.Models;

namespace LexicalAnalyzer.Services.IdCreationServices
{
    public class Id2CreationService
    {
        public string MakeId()
        {
            string result = AddStartSymbol() + AddSymbols(20);
            return result;
        }
        private char AddStartSymbol()
        {
            Random random = new();
            return IdTokenConstants.StartSymbolsForId2[random.Next(0, IdTokenConstants.StartSymbolsForId2.Length)];
        }
        private string AddSymbols(int count)
        {
            StringBuilder builder = new();
            Random random = new();
            for (int i = 0; i < count; i++)
            {
                builder.Append(IdTokenConstants.SymbolsForId2[random.Next(0, IdTokenConstants.SymbolsForId2.Length)]);
            }
            return builder.ToString();
        }
       
       
    }
}