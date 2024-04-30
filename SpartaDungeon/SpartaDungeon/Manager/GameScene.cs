
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public class GameScene
{

    private ChoiseJob choiseJob; //객체 필드추가
    private IPlayer player; //플레이어 초기화 변수
    private Inventory inventory;

    public GameScene()
    {
        InitializeGame();
    }

    // GameScene 초기화 함수
    private void InitializeGame()
    {
        inventory = new Inventory();

        inventory.items.Add(new Item("무쇠갑옷", 0, 5, 0, "튼튼한 갑옷", "방어력", false, false, 1));
        inventory.items.Add(new Item("강철갑옷", 0, 10, 0, "튼튼한 강철", "방어력", false, false, 1));
        inventory.items.Add(new Item("낡은 검", 10, 0, 0, "낡은 검", "공격력", false, false, 1));
        inventory.items.Add(new Item("강철 검", 20, 0, 0, "강철 검", "공격력", false, false, 1));
        inventory.items.Add(new Item("포션", 0, 0, 30, "포션", "물약", false, false, 3));
    }

    public BattleScene battleScene;
    public IPlayer player;

    bool check = true;

    public void InitDataSetting()
    {
        battleScene = new BattleScene();
        battleScene.SettingEnemyData();
    }


    public void StartView()
    {
        Console.Clear();
        ConsoleUtility.HeightPadding();

        Console.WriteLine(string.Format("{0}", "스파르타 던전").PadLeft(42 - (21 - ("스파르타 던전".Length / 2))));

        ConsoleUtility.HeightPadding();

        // 이름 물어보기
        Console.Write(string.Format("{0}", "닉네임 : ").PadLeft(42 - (29 - ("닉네임 : ".Length / 2))));
        string name = Console.ReadLine();   //닉네임 입력받기 추가
        Console.WriteLine();
        Console.WriteLine();
        // 직업
        Console.Write(string.Format("{0}", "1. 전사  |  2. 마법사 ").PadLeft(42 - (19 - ("1. 전사  |  2. 마법사 ".Length / 2))));
        Console.WriteLine();
        Console.WriteLine();
        // 직업 고르기
        Console.Write(string.Format("{0}", "캐릭터 선택 : ").PadLeft(42 - (27 - ("캐릭터 선택 : ".Length / 2))));
        int choice = int.Parse(Console.ReadLine());     //캐릭터 선택 입력받기 추가
        choiseJob = new ChoiseJob(name, choice);
        Console.WriteLine();

        //player = new Warrior(name, "Warrior", 1, 10, 10, 100, 50, 15000); //Test

        ConsoleUtility.HeightPadding();

        Console.WriteLine("=================================================");
        Console.WriteLine("              PRESS ANYKEY TO START              ");
        Console.WriteLine("=================================================");
        Console.ReadKey();

        InitDataSetting();
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
        Console.WriteLine("  2. 인벤토리");
        Console.WriteLine("  3. 전투 시작");
        ConsoleUtility.HeightPadding();

        // 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(1, 3);

        // 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 1:
                StatusView();
                break;
            case 2:
                InventoryView();
                break;
            case 3:
                battleScene.InitSettingDungeon(player);
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

        if (choiseJob != null)          //선택한 직업 상태보기 연결
        {
            if (choiseJob.Warrior != null)
            {
                Warrior warrior = choiseJob.Warrior;
                Console.WriteLine($"  LV. {warrior.Level}");
                Console.WriteLine($"  {warrior.Name} ({warrior.Job})");
                Console.WriteLine($"  공격력 : {warrior.Atk}");
                Console.WriteLine($"  방어력 :  {warrior.Def}");
                Console.WriteLine($"  Gold : {warrior.Gold}");
            }
            else if (choiseJob.Wizard != null)
            {
                Wizard wizard = choiseJob.Wizard;
                Console.WriteLine($"  LV. {wizard.Level}");
                Console.WriteLine($"  {wizard.Name} ({wizard.Job})");
                Console.WriteLine($"  공격력 : {wizard.Atk}");
                Console.WriteLine($"  방어력 :  {wizard.Def}");
                Console.WriteLine($"  Gold : {wizard.Gold}");
            }
        }

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

    private void InventoryView()
    {
        Console.Clear();
        Console.WriteLine();

        // 제목 색 다름
        ConsoleUtility.ShowTitle("  인벤토리");
        Console.WriteLine("  보유 중인 아이템을 관리할 수 있습니다.");
        ConsoleUtility.HeightPadding();

        Console.WriteLine("  [아이템 목록]]");
        //아이템 불러오기
        inventory.ShowInvenList();
        ConsoleUtility.HeightPadding();

        Console.WriteLine("  1. 장착하기");
        Console.WriteLine("  2. 포션 사용하기");
        Console.WriteLine("  0. 나가기");
        Console.WriteLine();

        // 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(0, 2);

        // 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 0:
                MainView();
                break;
            case 1:
                EquipView();
                break;
            case 2:
                UseView();
                break;
        }
        InventoryView();
    }

    private void UseView()
    {
        Console.Clear();
        Console.WriteLine();

        // 제목 색 다름
        ConsoleUtility.ShowTitle("  회복");
        Console.WriteLine($"  포션을 사용하면 체력을 30 회복 할 수 있습니다. (남은 포션 : {inventory.CountPosion()})");
        ConsoleUtility.HeightPadding();

        Console.WriteLine("  1. 사용하기");
        Console.WriteLine("  0. 나 가 기");
        Console.WriteLine();

        // 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(0, inventory.items.Count);

        // 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 0:
                InventoryView();
                break;
            default:
                Console.Clear();
                inventory.UsePotion();
                //player.UsePotion();
                UseView();
                break;
        }
        UseView();
    }

    private void EquipView()
    {
        Console.Clear();
        Console.WriteLine();

        // 제목 색 다름
        ConsoleUtility.ShowTitle("  인벤토리 - 장착 관리");
        Console.WriteLine("  보유 중인 아이템을 장착할 수 있습니다.");
        ConsoleUtility.HeightPadding();

        Console.WriteLine("  [아이템 목록]");
        //아이템 불러오기
        inventory.ShowInvenList(true);
        ConsoleUtility.HeightPadding();

        Console.WriteLine("  0. 나가기");
        Console.WriteLine();

        // 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(0, inventory.items.Count);

        // 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 0:
                InventoryView();
                break;
            default:
                inventory.CheckEquipState(choice -1); // 착용 상태 변경
                EquipView();
                break;
        }
        EquipView();
    }

    private void BattleView()
    {   
        Console.Clear();
        Console.WriteLine();            

        // 제목 색 다름
        ConsoleUtility.ShowTitle("  Battle!!");
        ConsoleUtility.HeightPadding();

        //Console.WriteLine($"  LV.{0} {1} HP {2}"); //미니언.Level 미니언.Name 미니언.HP
        //Console.WriteLine($"  LV.{0} {1} HP {2}"); //대포미니언.Level 대포미니언.Name 대포미니언.HP
        //Console.WriteLine($"  LV.{0} {1} HP {2}"); //공허충.Level 공허충.Name 공허충.HP
        
        foreach(var e in battleScene.competeEnemys) //Add YH 
        {
            if(e.currentHP != 0)
            {
                Console.WriteLine($"  LV.{e.level} {e.name} HP {e.currentHP}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"  LV.{e.level} {e.name} HP Dead");
                Console.ResetColor();
            }
        }

        ConsoleUtility.HeightPadding();

        Console.WriteLine("  [내정보]");
        Console.WriteLine($"  LV.{player.Level} {player.Name}({player.Job})"); //player.Level player.Name player.Job
        Console.WriteLine($"  HP {player.MaxHp}/{player.CurrentHp}"); //player.MaxHp player.CurrentHP
        ConsoleUtility.HeightPadding();


        string option = check ? " 1. 공격" : " 0. 취소";
        Console.WriteLine(option);
        Console.WriteLine();
        int minOptionNum = check ? 1 : 0;
        int maxOptionNum = check ? 1 : battleScene.competeEnemys.Count;
        // 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(minOptionNum, maxOptionNum, check);

        // 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 0:
                check = true;
                BattleView();
                break;
            case 1:
            default:
                if (check == true)
                {
                    check = false;
                    BattleView();
                }
                else
                {
                    Battle(choice);
                }
                break;
        }
        BattleView();
    }

    /// <summary>
    /// Player and Monster Dungeon Screen
    /// </summary>
    /// <param name="ch">Player InputKey Number</param>
    /// <author> ChoiYunHwa </author>
    private void Battle(int ch)
    {
        Console.Clear();
        Console.WriteLine();
        // 제목 색 다름
        ConsoleUtility.ShowTitle("  Battle!!");
        ConsoleUtility.HeightPadding();

        battleScene.BattleDungeon(player, ch);

        string attacker = battleScene.AttackTurn ? player.Name : battleScene.orderEnemy.name ;
        string defender = battleScene.AttackTurn ? "LV" + battleScene.orderEnemy.level + " " + battleScene.orderEnemy.name : player.Name;
        int attackerDamage = battleScene.AttackTurn ? battleScene.PlayerAttackDamage : battleScene.orderEnemy.damage;

        if(battleScene.AttackTurn == true)
            battleScene.AttackTurn = false;              

        //Console.WriteLine($" AttackTurn : {battleScene.AttackTurn}");

        Console.WriteLine($"  {attacker} 의 공격!");
        Console.WriteLine($"\n  {defender} 을(를) 맞췄습니다. [데미지 : {attackerDamage}]") ;


        Console.WriteLine("\n  0. 다음");
        Console.WriteLine();      


        int choice = ConsoleUtility.PromptMenuChoice(0, battleScene.competeEnemys.Count);

        //if( battleScene.orderEnemy == battleScene.competeEnemys.Last())
        //    BattleView();

        //ERROR 
        if (battleScene.orderEnemy != battleScene.competeEnemys.Last() && (battleScene.IsAttack == true || player.CurrentHp > 0))
        {
            Battle(choice);
        }
        else if (battleScene.AttackTurn = false && battleScene.orderEnemy == battleScene.competeEnemys.Last()) 
        {
            battleScene.AttackTurn = true;
            battleScene.turnCount = 0;
            BattleView();
        }
        
        if(battleScene.isEnding == true)
        {
            ResultBattle();
        }
    }

    /// <summary>
    /// Show the results after the battle
    /// </summary>
    /// <author> ChoiYunHwa </author>
    private void ResultBattle()
    {
        Console.Clear();
        Console.WriteLine();
        // 제목 색 다름
        ConsoleUtility.ShowTitle("  Battle!! - Result");
        ConsoleUtility.HeightPadding();

        var Color = player.CurrentHp > 0 ? ConsoleColor.Green : ConsoleColor.Red;
        Console.ForegroundColor = Color;
        string result = player.CurrentHp > 0 ? "  Victory" : "  You Lose";        
        Console.WriteLine(result);
        Console.ResetColor();
        ConsoleUtility.HeightPadding();
        Console.WriteLine($"LV. {player.Level} {player.Name}");
        Console.WriteLine($"HP {battleScene.tempPlayerHealth} -> {player.CurrentHp}");

        ConsoleUtility.HeightPadding();
        Console.WriteLine("\n  0. 다음");

        int choice = ConsoleUtility.PromptMenuChoice(0, battleScene.competeEnemys.Count);

        switch (choice)
        {
            case 0:
                MainView();
                break;            
        }
    }

}