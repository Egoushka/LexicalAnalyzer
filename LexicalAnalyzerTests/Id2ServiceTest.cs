using System;
using LexicalAnalyzer.Services.IdCheckServices;
using LexicalAnalyzer.Services.IdCreationServices;
using Xunit;

namespace LexicalAnalyzerTests
{
    public class Id2ServiceTest
    {
        private Id2CheckService _checkService = new();
        private Id2CreationService _creationService = new();
        [Fact]
        public void SuccessfulValidateId()
        {
            string id = _creationService.MakeId();

            Assert.True(_checkService.CheckId(id));
        }
        [Fact]
        public void FailedValidateId()
        {
            string id = '1' + _creationService.MakeId();

            Assert.False(_checkService.CheckId(id));
        }
    }
}