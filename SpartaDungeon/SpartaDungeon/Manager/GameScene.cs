﻿
public class GameScene
{
    public void StartView()
    {
        Console.Clear();
        ConsoleUtility.HeightPadding();

        Console.WriteLine(string.Format("{0}", "스파르타 던전").PadLeft(42 - (21 - ("스파르타 던전".Length / 2))));

        ConsoleUtility.HeightPadding();

        // 이름 물어보기
        Console.Write(string.Format("{0}", "닉네임 : ").PadLeft(42 - (29 - ("닉네임 : ".Length / 2))));
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine();
        // 직업
        Console.Write(string.Format("{0}", "1. 전사  |  2. 마법사 ").PadLeft(42 - (19 - ("1. 전사  |  2. 마법사 ".Length / 2))));
        Console.WriteLine();
        Console.WriteLine();
        // 직업 고르기
        Console.Write(string.Format("{0}", "캐릭터 선택 : ").PadLeft(42 - (27 - ("캐릭터 선택 : ".Length / 2))));
        Console.ReadLine();
        Console.WriteLine();

        ConsoleUtility.HeightPadding();

        Console.WriteLine("=================================================");
        Console.WriteLine("              PRESS ANYKEY TO START              ");
        Console.WriteLine("=================================================");
        Console.ReadKey();
        MainView();
    }

    public void MainView()
    {
        Console.Clear();
        Console.WriteLine();

        Console.WriteLine("  스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("  이제 전투를 시작할 수 있습니다. ");
        ConsoleUtility.HeightPadding();

        Console.WriteLine("  1. 상태 보기");
        Console.WriteLine("  2. 전투 시작");
        ConsoleUtility.HeightPadding();

        // 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(1, 2);

        // 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 1:
                StatusView();
                break;
            case 2:
                BattleView();
                break;
        }
        MainView();
    }


    private void StatusView()
    {
        Console.Clear();
        Console.WriteLine();

        // 제목 색 다름
        ConsoleUtility.ShowTitle("  상태 보기");
        Console.WriteLine("  캐릭터의 정보가 표기됩니다.");
        ConsoleUtility.HeightPadding();

        Console.WriteLine($"  LV. {0}"); //player.Level
        Console.WriteLine($"  {0} ({1})"); //player.Name, player.Job
        Console.WriteLine($"  공격력 : {0}"); //player.Attack
        Console.WriteLine($"  방어력 :  {0}"); //player.Defense
        Console.WriteLine($"  Golde : {0}"); //player.Gold
        ConsoleUtility.HeightPadding();

        Console.WriteLine("  0. 나가기");
        Console.WriteLine();

        // 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(0, 0);

        // 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 0:
                MainView();
                break;
        }
        StatusView();
    }

    private void BattleView()
    {
        Console.Clear();
        Console.WriteLine();

        // 제목 색 다름
        ConsoleUtility.ShowTitle("  Battle!!");
        ConsoleUtility.HeightPadding();

        Console.WriteLine($"  LV.{0} {1} HP {2}"); //미니언.Level 미니언.Name 미니언.HP
        Console.WriteLine($"  LV.{0} {1} HP {2}"); //대포미니언.Level 대포미니언.Name 대포미니언.HP
        Console.WriteLine($"  LV.{0} {1} HP {2}"); //공허충.Level 공허충.Name 공허충.HP
        ConsoleUtility.HeightPadding();

        Console.WriteLine("  [내정보]");
        Console.WriteLine($"  LV.{0} {1}({2})"); //player.Level player.Name player.Job
        Console.WriteLine($"  HP {0}/{1}"); //player.MaxHp player.CurrentHP
        ConsoleUtility.HeightPadding();

        Console.WriteLine("  1. 공격");
        Console.WriteLine();

        // 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(1, 1);

        // 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 1:
                //Battle();
                break;
        }
        BattleView();
    }
}