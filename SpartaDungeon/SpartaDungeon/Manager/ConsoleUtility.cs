
using System.Runtime.CompilerServices;


public class ConsoleUtility
{
    public static int PromptMenuChoice(int min, int max, bool check = true)
    {
        while (true)
        {
            if (check)
                Console.WriteLine("  원하시는 번호를 입력해주세요.");
            else
                Console.WriteLine("  대상을 선택해주세요.");

            Console.Write("  >> ");
            if (int.TryParse(Console.ReadLine(), out var choice) && choice >= min && choice <= max)
            {
                return choice;
            }
            Console.WriteLine("  잘못된 입력입니다. 다시 시도해주세요.");
        }
    }
    internal static void ShowTitle(string title)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(title);
        Console.ResetColor();
    }

    public static int GetPrintableLength(string str)
    {
        int length = 0;
        foreach (char c in str)
        {
            if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
            {
                length += 2; // 한글과 같은 넓은 문자에 대해 길이를 2로 취급
            }
            else
            {
                length += 1; // 나머지 문자에 대해 길이를 1로 취급
            }
        }
        return length;
    }

    public static void PrintTextHighlights(string s1, string s2, string s3 = "")
    {
        Console.WriteLine(s1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(s2);
        Console.WriteLine();
        Console.WriteLine(s3);
    }

    public static void HeightPadding()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }

    public static string PadRightForMixedText(string str, int totalLength)    //문구 정렬 추가
    {
        // 가나다
        // 111111
        int currentLength = GetPrintableLength(str);
        int padding = totalLength - currentLength;
        return str.PadRight(str.Length + padding);
    }

}