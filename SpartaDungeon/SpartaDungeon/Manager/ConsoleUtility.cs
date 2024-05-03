
using System.Runtime.CompilerServices;


public class ConsoleUtility
{
    
    /// <summary>
    /// 플레이어 입력 값이 올바른 입력인지 확인
    /// </summary>
    /// <param name="min">플레이어가 고를 수 있는 최소 숫자</param>
    /// <param name="max">플레이어가 고를 수 있는 최대 숫자</param>
    /// <param name="check"></param>
    /// <returns>choice</returns>
    /// <author> SooHyeonKim </author>
    public static int PromptMenuChoice(int min, int max, EScreenView option = EScreenView.BASIC)
    {
        while (true)
        {

            switch (option)
            {
                case EScreenView.BASIC:
                case EScreenView.MAIN_BATTLE:
                    Console.WriteLine("  원하시는 행동을 선택해주세요.");
                    break;
                case EScreenView.SKILL_BATTLE:
                    Console.WriteLine("  스킬을 선택해주세요.");
                    break;
                case EScreenView.ENEMY_BATTLE:
                    Console.WriteLine("  대상을 선택해주세요.");
                    break;
                case EScreenView.QUEST:
                    Console.WriteLine("  원하는 퀘스트를 선택해주세요.");
                    break;
            }

            Console.Write("  >> ");
            if (int.TryParse(Console.ReadLine(), out var choice) && choice >= min && choice <= max)
            {
                return choice;
            }
            Console.WriteLine("  잘못된 입력입니다. 다시 시도해주세요.");
        }
    }

    /// <summary>
    /// 문자 색 변경
    /// </summary>
    /// <param name="title">title 문자</param>
    /// <author> SooHyeonKim </author>
    public static void ShowTitle(string title)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(title);
        Console.ResetColor();
    }

    /// <summary>
    /// 문자 길이 확인
    /// </summary>
    /// <param name="str"></param>
    /// <returns>문자길이</returns>
    /// <author> SooHyeonKim </author>
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

    /// <summary>
    /// 글자 간격 패딩
    /// </summary>
    /// <author> SooHyeonKim </author>
    public static void HeightPadding()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }

    /// <summary>
    /// 문자 정렬
    /// </summary>
    /// <param name="str"></param>
    /// <param name="totalLength"></param>
    /// <author> SooHyeonKim </author>
    public static string PadRightForMixedText(string str, int totalLength)
    {
        // 가나다
        // 111111
        int currentLength = GetPrintableLength(str);
        int padding = totalLength - currentLength;
        return str.PadRight(str.Length + padding);
    }

}