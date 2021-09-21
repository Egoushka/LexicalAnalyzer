namespace LexicalAnalyzer.Constants
{
    public static class AnalyzerConstants
    {
        public static readonly char[] Separators = {' ', '(', ')', ',', ';'};
        
        public static readonly char[] LiteralSeparators = {'\''};
        
        public static readonly string[] LogicSymbols = {">", "<", ":="};

        public static readonly string[] Keywords =
        {
            "create",
            "itersect",
            "union",
            "table",
            "integer",
            "into",
            "insert",
            "text",
            "where",
            "beginra",
            "endra",
            "values"
        };
    }
}