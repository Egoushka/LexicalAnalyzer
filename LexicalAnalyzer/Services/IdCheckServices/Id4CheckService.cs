using System;
using System.Text;
using System.Text.RegularExpressions;
using LexicalAnalyzer.Models;

namespace LexicalAnalyzer.Services.IdCheckServices
{
    public class Id4CheckService : IdCheckerService
    {
        private string regex = "^[a-zA-Z_]+[a-zA-Z0-9_]*$";
        public bool CheckId(string id)
        {
            return Regex.IsMatch(id, regex);
        }
    }
}