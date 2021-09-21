using LexicalAnalyzer.Models;
using LexicalAnalyzer.Services;
using Xunit;

namespace LexicalAnalyzerTests
{
    public class ExpressionTest
    {
        private ExpressionService _expressionService = new();
        
        [Fact]
        public void SuccessfulQueryCountValidate()
        {
            string query = "T12 := TE4 ITERSECT (EML union DEP2 WHERE SALARY > 401";
            
            _expressionService.ProcessQuery(query);
            
            Assert.True(_expressionService.UniqueTokensCount.Equals(11));
        }   
        [Fact]
        public void SuccessfulQueryCountValidate2()
        {
            string query = "BeginRA "+
                           "Create table CYCLE (KodCycl integer, NazvCycl text (60));"+ 
                           "Insert into CYCLE values (1, 'Цикл ГСЕ дисциплін вибору')"+
                           "EndRA";
            
            _expressionService.ProcessQuery(query);
            
            Assert.True(_expressionService.UniqueTokensCount.Equals(15));
        }  

    }
}