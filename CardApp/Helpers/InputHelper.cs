using System.Text.RegularExpressions;

public static class InputHelper
{
   public static bool IsValidInputString(string inputString) {
        string pattern = @"[^a-zA-Z0-9,]+";

        return !Regex.IsMatch(inputString, pattern);
    }
}