using System;
using System.Text;
using System.Text.RegularExpressions;
using LexicalAnalyzer.Models;

namespace LexicalAnalyzer.Services.IdCheckServices
{
    public class Id2CheckService : IdCheckerService
    {
        private string regex = "^[a-zA-Z-]+[a-zA-Z0-9-]*$";
        public bool CheckId(string id)
        {
            return Regex.IsMatch(id, regex);
        }
    }
}