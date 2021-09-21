namespace LexicalAnalyzer.Constants
{
    public static class IdTokenConstants
    {
        public static readonly string LowerRegisterLetters = "abcdefghijklmnopqrstuvwxyz";
        public static readonly string UpperRegisterLetters = LowerRegisterLetters.ToUpper();
        public static readonly string Numbers = "0123456789";
        
        public static readonly char Hyphen = '-';
        public static readonly char Underscore = '-';
        
        public static readonly string StartSymbolsForId2 = LowerRegisterLetters + UpperRegisterLetters + Underscore;
        public static readonly string StartSymbolsForId4 = LowerRegisterLetters + UpperRegisterLetters + Hyphen;

        public static readonly string SymbolsForId2 = LowerRegisterLetters + UpperRegisterLetters + Numbers + Underscore;
        public static readonly string SymbolsForId4 = LowerRegisterLetters + UpperRegisterLetters + Numbers + Hyphen;
    }
}