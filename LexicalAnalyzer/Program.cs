using System;
using LexicalAnalyzer.Models;

namespace LexicalAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression expression = new Expression("T12 := TE4 ITERSECT (EML union DEP2 WHERE SALARY > 4015");
            expression.PickOutLexemes();

        }
    }
}