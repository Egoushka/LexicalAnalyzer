using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using LexicalAnalyzer.Models;
using LexicalAnalyzer.Services;
using LexicalAnalyzer.Services.IdCreationServices;
using Newtonsoft.Json;

namespace LexicalAnalyzer
{
    class Program
    {
        static ExpressionService expression = new();

        static string query1 = "T12 := TE4 ITERSECT (EML union DEP2 WHERE SALARY > 401";
        static string query2 = "BeginRA "+
                              "Create table CYCLE (KodCycl integer, NazvCycl text (60));"+ 
                              "Insert into CYCLE values (1, 'Цикл ГСЕ дисциплін вибору')"+
                              "EndRA";
        static void Main(string[] args)
        {
            ProcessQuery1();

        }

        static void ProcessQuery1()
        {
            expression.ProcessQuery(query1);
            Console.WriteLine(JsonConvert.SerializeObject(expression.Tokens, Formatting.Indented));
        }  
        static void ProcessQuery2()
        {
            expression.ProcessQuery(query2);
            Console.WriteLine(JsonConvert.SerializeObject(expression.Tokens, Formatting.Indented));
        }
    }
}