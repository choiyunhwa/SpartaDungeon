
using SpartaDungeon;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

public class GameScene
{

    //private IPlayer player; //플레이어 초기화 변수
    private Inventory inventory; //인벤토리 초기화 변수
    public BattleScene battleScene; //배틀씬 초기화 변수
    public static IPlayer player; //플레이어 초기화 변수
    public static List<Skill> SkillList = new List<Skill>();
    public AllQuestList allQuestList;


    bool check = true;
    bool skillCheck = false;
    EScreenView currentView = EScreenView.MAIN_BATTLE;


    public GameScene()
    {
        //StartView();

        IntroView();
    }

    public void InitDataSetting()
    {
        allQuestList = new AllQuestList();
        /// <author> SooHyeonKim </author>
        inventory = new Inventory(player, allQuestList);
        inventory.items.Add(new Item("무쇠갑옷", 0, 5, 0, "튼튼한 갑옷", "방어력", false, false, 1));
        inventory.items.Add(new Item("강철갑옷", 0, 10, 0, "튼튼한 강철", "방어력", false, false, 1));
        inventory.items.Add(new Item("낡은 검", 10, 0, 0, "낡은 검", "공격력", false, false, 1));
        inventory.items.Add(new Item("강철 검", 20, 0, 0, "강철 검", "공격력", false, false, 1));
        inventory.items.Add(new Item("포션", 0, 0, 30, "포션", "물약", false, false, 3));


        /// <author> ChoiYunHwa </author>
        battleScene = new BattleScene(allQuestList);
        battleScene.SettingEnemyData();
    }
    /// <summary>
    /// GameStart Intro Ani
    /// </summary>
    /// <author> ChoiYunHwa </author>
    public void IntroView()
    {
        bool colorCheck = false;
        string introText =
            ("\n\n\n\n\n                ::::::::      :::::::::         :::         :::::::::   :::::::::::       ::: "
           + "\n              :+:    :+:     :+:    :+:      :+: :+:       :+:    :+:      :+:         :+: :+:"
           + "\n             +:+            +:+    +:+     +:+   +:+      +:+    +:+      +:+        +:+   +:+"
           + "\n            +#++:++#++     +#++:++#+     +#++:++#++:     +#++:++#:       +#+       +#++:++#++:"
           + "\n                  +#+     +#+           +#+     +#+     +#+    +#+      +#+       +#+     +#+ "
           + "\n          #+#    #+#     #+#           #+#     #+#     #+#    #+#      #+#       #+#     #+#  "
           + "\n          ########      ###           ###     ###     ###    ###      ###       ###     ###   ");


        ConsoleUtility.TextColor(ConsoleColor.DarkGray, introText);
        Thread.Sleep(500);
        Console.Clear();
        ConsoleUtility.TextColor(ConsoleColor.Gray, introText);
        Thread.Sleep(500);
        Console.Clear();
        ConsoleUtility.TextColor(ConsoleColor.Red, introText);

        while (true)
        {
            colorCheck = !colorCheck;
            Console.Clear();
            ConsoleUtility.TextColor(ConsoleColor.Red, introText);
            ConsoleColor color = colorCheck ? ConsoleColor.Gray : ConsoleColor.DarkGray;
            Console.ForegroundColor = color;
            Console.WriteLine("\n\n\n                                 <<     PRESS ANYKEY TO START     >>");
            Console.ResetColor();

            Thread.Sleep(400);

            if (Console.KeyAvailable)
            {
                Console.ReadKey();
                break;
            }
        }
        StartView();
    }



    /// <summary>
    /// screen for start game
    /// </summary>
    /// <author> SooHyeonKim </author>
    public void StartView()
    {
        string job = "";

        Console.Clear();
        ConsoleUtility.HeightPadding();

        Console.WriteLine(string.Format("{0}", "닉네임과 직업을 선택해주세요.").PadLeft(42 - (21 - ("닉네임과 직업을 선택해주세요.".Length / 2))));

        ConsoleUtility.HeightPadding();

        // 이름 물어보기
        Console.Write(string.Format("{0}", "닉네임 : ").PadLeft(42 - (29 - ("닉네임 : ".Length / 2))));
        string name = Console.ReadLine();   //닉네임 입력받기 추가

        if (!string.IsNullOrEmpty(name))
        {
            Console.WriteLine();
            Console.WriteLine();
            // 직업
            Console.Write(string.Format("{0}", "1. 전사  |  2. 마법사 ").PadLeft(42 - (19 - ("1. 전사  |  2. 마법사 ".Length / 2))));
            Console.WriteLine();
            Console.WriteLine();
            // 직업 고르기
            Console.Write(string.Format("{0}", "캐릭터 선택 : ").PadLeft(42 - (27 - ("캐릭터 선택 : ".Length / 2))));

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice <= 2 && choice > 0)//캐릭터 선택 입력받기 추가
                {
                    switch (choice)
                    {
                        case 1:
                            player = new Warrior(name, "Warrior", 1, 10, 10, 100, 50, 15000);
                            break;
                        case 2:
                            player = new Wizard(name, "Wizard", 1, 5, 5, 80, 100, 15000);
                            break;
                    }
                    break;
                }
                else
                {
                    ConsoleUtility.HeightPadding();
                    Console.WriteLine("          잘못입력했습니다. 다시 입력해주세요.");
                }
            }

            Console.WriteLine();
            Console.Clear();
            ConsoleUtility.HeightPadding();
            switch (player.Job)
            {
                case "Warrior":
                    job = "전사";
                    break;
                case "Wizard":
                    job = "마법사";
                    break;
            }

            Console.WriteLine($"                {player.Name}님 {job} 직업의 캐릭터를 생성하였습니다.");
            ConsoleUtility.HeightPadding();
            Console.WriteLine("          =================================================");
            Console.WriteLine("                        PRESS ANYKEY TO START              ");
            Console.WriteLine("          =================================================");
            Console.ReadKey();

            // 초기화(인벤토리, 던전)
            InitDataSetting();
            MainView();
        }
        else
        {
            Console.WriteLine("\n          닉네임을 입력해주세요.");
            Thread.Sleep(300);
            StartView();
        }
    }

    /// <summary>
    /// screen for main menu
    /// </summary>
    /// <author> SooHyeonKim </author>
    public void MainView()
    {
        Console.Clear();
        Console.WriteLine();

        Console.WriteLine("  스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("  이제 전투를 시작할 수 있습니다. ");
        ConsoleUtility.HeightPadding();

        Console.WriteLine("  1. 상태 보기");
        Console.WriteLine("  2. 인벤토리");
        Console.WriteLine($"  3. 전투 시작 (현재 진행 :{player.CurrentDungenon} 층)");
        Console.WriteLine("  4. 퀘스트 확인");
        ConsoleUtility.HeightPadding();

        // 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(1, 4);

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
                if (player.CurrentHp > 0)
                {
                    battleScene.InitSettingDungeon(player, player.CurrentDungenon);
                    BattleView();
                }
                else
                {
                    Console.WriteLine($"\n{player.Name}님의 체력이 없습니다.");
                    Thread.Sleep(400);
                }

                break;
            case 4:
                QuestView();
                break;
        }
        MainView();
    }

    /// <summary>
    /// screen for checking player's status
    /// </summary>
    /// <author> SooHyeonKim </author>
    private void StatusView()
    {
        Console.Clear();
        Console.WriteLine();

        // 제목 색 다름
        ConsoleUtility.ShowTitle("  상태 보기");
        Console.WriteLine("  캐릭터의 정보가 표기됩니다.");
        ConsoleUtility.HeightPadding();

        Console.WriteLine($"  LV. {player.Level}");
        Console.WriteLine($"  {player.Name} ({player.Job})");
        //Console.WriteLine($"  공격력 : {player.Atk}"); // AddAtk 추가로 수정하였습니다.
        //Console.WriteLine($"  방어력 :  {player.Def}"); // AddDef 추가로 수정하였습니다.
        if (player.AddAtk == 0) Console.WriteLine($"  공격력 : {player.Atk}");
        else Console.WriteLine($"  공격력 : {player.Atk} (+{player.AddAtk})");
        if (player.AddDef == 0) Console.WriteLine($"  방어력 : {player.Def}");
        else Console.WriteLine($"  방어력 : {player.Def} (+{player.AddDef})");
        Console.WriteLine("  체력 : " + player.CurrentHp);
        Console.WriteLine($"  Gold : {player.Gold}");

        //for (int i = 0; i < SkillList.Count; i++)
        //{
        //    SkillList[i].PrintSkillDescription(i + 1);
        //}

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

    /// <summary>
    /// screen for checking player's item list
    /// </summary>
    /// <author> SooHyeonKim </author>
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

    /// <summary>
    /// Screen for using items
    /// </summary>
    /// <author> SooHyeonKim </author>
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
                player.UsePotion();
                UseView();
                break;
        }
        UseView();
    }

    /// <summary>
    /// screen for Equipping items
    /// </summary>
    /// <author> SooHyeonKim </author>
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
                inventory.CheckEquipState(choice - 1); // 착용 상태 변경
                EquipView();
                break;
        }
        EquipView();
    }




    public void UseSkill(int num) // 해금이됬는가->마나가 있는가->실패가능성있는스킬인가->랜덤스킬인가
    {

        while (true)
        {
            if (!SkillList[num - 1].Unlocked)
            {
                Console.WriteLine("스킬이 해금되지 않았습니다.");
                Console.WriteLine("계속하려면 아무 키나 누르세요...");
                Console.ReadKey();
                break;
            }
            else
            {
                if (player.CurrentMP >= SkillList[num - 1].Mana)
                {
                    if (SkillList[num - 1].CanAttack())
                    {
                        if (SkillList[num - 1].IsRandom)
                        {
                            player.CurrentMP -= SkillList[num - 1].Mana;
                            int damage = SkillList[num - 1].CalculateDamage();
                            int[] selectedIndexes = battleScene.RandomAttack();

                            Battle(0, damage, selectedIndexes);

                        }
                        else
                        {
                            Console.WriteLine("대상을 선택해주세요: ");
                            int enemynum = int.Parse(Console.ReadLine());
                            int damage = SkillList[num - 1].CalculateDamage();
                            player.CurrentMP -= SkillList[num - 1].Mana;
                            Battle(enemynum, damage, null);
                        }
                    }
                    else
                    {
                        Console.WriteLine("공격에 실패했습니다.");
                        Console.WriteLine("계속하려면 아무 키나 누르세요...");
                        Console.ReadKey();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("마나가 부족합니다.");
                    Console.WriteLine("계속하려면 아무 키나 누르세요...");
                    Console.ReadKey();
                    break;
                }
            }
        }

    }

    /// <summary>
    /// Screen for Battle
    /// </summary>
    /// <author> ChoiYunHwa </author>
    private void BattleView()
    {
        Console.Clear();
        Console.WriteLine();

        // 제목 색 다름
        ConsoleUtility.ShowTitle("  Battle!!");
        ConsoleUtility.HeightPadding();

        int i = 1;
        foreach (var e in battleScene.competeEnemys) //Add YH 
        {
            string num = check ? "" : $"{i}";
            if (e.currentHP != 0)
            {
                Console.WriteLine($" {num} - LV.{e.level} {e.name} HP {e.currentHP}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($" {num} - LV.{e.level} {e.name} HP Dead");
                Console.ResetColor();
            }
            i++;
        }

        ConsoleUtility.HeightPadding();

        Console.WriteLine("  [내정보]");
        Console.WriteLine($"  LV.{player.Level} {player.Name}({player.Job})");
        Console.WriteLine($"  HP {player.MaxHp}/{player.CurrentHp}");
        Console.WriteLine($"  MP {player.MaxMP}/{player.CurrentMP}");
        ConsoleUtility.HeightPadding();

        int maxOptionNum = ShowSelectBattleView(currentView);
        Console.WriteLine();
        // 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(0, maxOptionNum, currentView);

        switch (currentView)
        {
            case EScreenView.MAIN_BATTLE:
                if (choice == 0)
                {
                    MainView();
                }
                else if (choice == 1)
                {
                    currentView = EScreenView.ENEMY_BATTLE;
                }
                else
                {
                    currentView = EScreenView.SKILL_BATTLE;
                }
                break;
            case EScreenView.SKILL_BATTLE:
                if (choice == 0)
                {
                    currentView = EScreenView.MAIN_BATTLE;
                }
                else
                {
                    UseSkill(choice);
                }
                break;
            case EScreenView.ENEMY_BATTLE:
                if (choice == 0)
                {
                    currentView = EScreenView.MAIN_BATTLE;
                }
                else
                {
                    if (ConsoleUtility.MonsterChoice(choice, battleScene.competeEnemys) == true)
                        Battle(choice, 0, null);
                }
                break;
        }
        BattleView();
    }

    /// <summary>
    /// Show Current View
    /// </summary>
    /// <param name="view"> Enum current view information </param>
    /// <returns> Maximum number on the current Screen </returns>
    /// <author> ChoiYunHwa </author>
    private int ShowSelectBattleView(EScreenView view)
    {
        string option = "";
        int maxMenuNum = 0;
        switch (view)
        {
            case EScreenView.MAIN_BATTLE:
                option = " 1.공격\n 2.스킬 \n\n 0.나가기";
                maxMenuNum = 2;
                break;
            case EScreenView.SKILL_BATTLE:
                for (int i = 0; i < SkillList.Count; i++)
                {
                    if (SkillList[i].Unlocked)
                    {
                        Console.Write("   [");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("U");
                        Console.ResetColor();
                        Console.Write("]");
                    }
                    Console.WriteLine($"  {i + 1}.{SkillList[i].Name} - MP {SkillList[i].Mana}");
                    Console.WriteLine($"    {SkillList[i].Description}");
                }
                option = "  0. 취소";
                maxMenuNum = SkillList.Count; //ADD : UnLock Skill Count
                break;
            case EScreenView.ENEMY_BATTLE:
                option = "  0. 나가기";
                maxMenuNum = battleScene.competeEnemys.Count;
                break;
        }

        Console.WriteLine(option);
        Console.WriteLine();

        return maxMenuNum;
    }

    /// <summary>
    /// Player and Monster Dungeon Screen
    /// </summary>
    /// <param name="ch">Player InputKey Number</param>
    /// <author> ChoiYunHwa </author>
    private void Battle(int ch, int skillDamage, int[] RandomEnemy)
    {
        int temp = skillDamage;
        int[] randem = RandomEnemy;
        ConsoleColor color;

        Console.Clear();
        Console.WriteLine();
        // 제목 색 다름

        ConsoleUtility.ShowTitle("  Battle!!");
        ConsoleUtility.HeightPadding();

        string attacker;
        string defender;
        int attackerDamage;

        if (RandomEnemy != null)
        {
            for (int i = 0; i < RandomEnemy.Length; i++)
            {
                ch = RandomEnemy[i];
                battleScene.BattleDungeon(player, ch, skillDamage);
                if (!object.ReferenceEquals(null, battleScene.currentEnemy))
                    if (battleScene.currentEnemy.isDead == true && battleScene.AttackTurn == false)
                        Battle(0, temp, randem);
                attacker = battleScene.AttackTurn ? player.Name : battleScene.orderEnemy.name;
                defender = battleScene.AttackTurn ? "LV" + battleScene.orderEnemy.level + " " + battleScene.orderEnemy.name : player.Name;
                attackerDamage = battleScene.AttackTurn ? battleScene.PlayerAttackDamage : battleScene.orderEnemy.damage;
                if (battleScene.AttackTurn == true)
                    battleScene.AttackTurn = false;
                Console.WriteLine($"  {attacker} 의 공격!");
                Console.WriteLine($"\n  {defender} 을(를) 맞췄습니다. [데미지 : {attackerDamage}]");

                if (battleScene.AttackTurn == false)
                {
                    string damageTxt = "";
                    switch (battleScene.orderEnemy.eAttackInfor)
                    {
                        case EAttackInfor.NONE:
                            damageTxt = $"\n   {battleScene.orderEnemy}의 공격이 빗나갔다. 운이 좋았던 것 같다.";
                            break;
                        case EAttackInfor.BASIC:
                            damageTxt = "";
                            break;
                        case EAttackInfor.CRITICAL:
                            damageTxt = $"\n   {battleScene.orderEnemy}의 치명적인 일격!";
                            break;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(damageTxt);
                    Console.ResetColor();
                }
                else
                {
                    string damageTxt = "";
                    switch (player.eAttackInfor)
                    {
                        case EAttackInfor.NONE:
                            damageTxt = $"\n   {battleScene.orderEnemy}가 민첩하게 {player.Name}의 공격을 피했습니다.";
                            break;
                        case EAttackInfor.BASIC:
                            damageTxt = "";
                            break;
                        case EAttackInfor.CRITICAL:
                            damageTxt = $"\n   {player.Name}가 강력한 일격을 퍼부었습니다! {battleScene.orderEnemy}는 치명적인 타격을 입었습니다.";

                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(damageTxt);
                    Console.ResetColor();
                }
            }

        }
        else
        {
            battleScene.BattleDungeon(player, ch, skillDamage);
            if (!object.ReferenceEquals(null, battleScene.currentEnemy))
                if (battleScene.currentEnemy.isDead == true && battleScene.AttackTurn == false)
                    Battle(0, temp, randem);
            attacker = battleScene.AttackTurn ? player.Name : battleScene.orderEnemy.name;
            defender = battleScene.AttackTurn ? "LV" + battleScene.orderEnemy.level + " " + battleScene.orderEnemy.name : player.Name;
            attackerDamage = battleScene.AttackTurn ? battleScene.PlayerAttackDamage : battleScene.orderEnemy.damage;

            if (battleScene.AttackTurn == true)
                battleScene.AttackTurn = false;

            Console.WriteLine($"  {attacker} 의 공격!");
            Console.WriteLine($"\n  {defender} 을(를) 맞췄습니다. [데미지 : {attackerDamage}]");

            if (battleScene.AttackTurn == false)
            {
                string damageTxt = "";
                switch (battleScene.orderEnemy.eAttackInfor)
                {
                    case EAttackInfor.NONE:
                        damageTxt = $"\n   {battleScene.orderEnemy}의 공격이 빗나갔다. 운이 좋았던 것 같다.";
                        break;
                    case EAttackInfor.BASIC:
                        damageTxt = "";
                        break;
                    case EAttackInfor.CRITICAL:
                        damageTxt = $"\n   {battleScene.orderEnemy}의 치명적인 일격!";
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(damageTxt);
                Console.ResetColor();
            }
            else
            {
                string damageTxt = "";
                switch (player.eAttackInfor)
                {
                    case EAttackInfor.NONE:
                        damageTxt = $"\n   {battleScene.orderEnemy}가 민첩하게 {player.Name}의 공격을 피했습니다.";
                        break;
                    case EAttackInfor.BASIC:
                        damageTxt = "";
                        break;
                    case EAttackInfor.CRITICAL:
                        damageTxt = $"\n   {player.Name}가 강력한 일격을 퍼부었습니다! {battleScene.orderEnemy}는 치명적인 타격을 입었습니다.";
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(damageTxt);
                Console.ResetColor();
            }

        }

        Console.WriteLine("\n  0. 다음");
        Console.WriteLine();


        int choice = ConsoleUtility.PromptMenuChoice(0, battleScene.competeEnemys.Count);


        if (battleScene.isEnding == true)
        {
            ResultBattle();
        }

        if (battleScene.currentEnemy != battleScene.competeEnemys.Last() && (battleScene.IsAttack == true || player.CurrentHp > 0))
        {
            Battle(choice, 0, null);
        }
        else if (battleScene.currentEnemy == battleScene.competeEnemys.Last() && (battleScene.IsAttack == true || player.CurrentHp > 0))
        {
            battleScene.currentEnemy = battleScene.competeEnemys.First();
            battleScene.AttackTurn = true;
            battleScene.turnCount = 0;

            currentView = EScreenView.MAIN_BATTLE;
            BattleView();
        }
        else
        {
            currentView = EScreenView.MAIN_BATTLE;
            BattleView();
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
        Console.WriteLine($"  LV. {player.Level} {player.Name}");
        Console.WriteLine($"\n  HP {battleScene.tempPlayerHealth} -> {player.CurrentHp}");

        /// <author> KwonSinWook </author>
        if (result == "  Victory")
        {
            Reward reward = new Reward();
            player.CurrentDungenon++;
            reward.GetReward(battleScene.competeEnemys, player); // 승리 시에만 전투 보상 지급
        }

        ConsoleUtility.HeightPadding();
        Console.WriteLine("\n  0. 다음");

        int choice = ConsoleUtility.PromptMenuChoice(0, battleScene.competeEnemys.Count);

        switch (choice)
        {
            case 0:
                currentView = EScreenView.MAIN_BATTLE;
                MainView();
                break;
        }
    }

    /// <summary>
    /// Show QuestView
    /// </summary>
    /// <author> ChoiYunHwa </author>
    private void QuestView()
    {
        Console.Clear();
        Console.WriteLine();
        // 제목 색 다름
        ConsoleUtility.ShowTitle("  퀘스트 확인");
        Console.WriteLine("  퀘스트를 확인하고 선택할 수 있습니다.");
        ConsoleUtility.HeightPadding();
        Console.WriteLine("  [ 목록 ] \n");

        // 퀘스트 목록 불러오기
        allQuestList.LoadQuestList();

        ConsoleUtility.HeightPadding();
        Console.WriteLine("\n  0. 나가기");
        int choice = ConsoleUtility.PromptMenuChoice(0, allQuestList.questsList.Count);

        switch (choice)
        {
            case 0:
                MainView();
                break;
            default:
                if (allQuestList.questsList[choice - 1].isRewarded == false) SelectQuestView(choice);
                else Console.WriteLine(" 완료된 퀘스트입니다.");
                Thread.Sleep(500);
                break;
        }

        QuestView();
    }

    /// <summary>
    /// Show Selected Quest Screen Information
    /// </summary>
    /// <param name="ch">Selecte Quest Number</param>
    /// <author> ChoiYunHwa </author>
    private void SelectQuestView(int ch)
    {
        Console.Clear();
        Console.WriteLine();
        // 제목 색 다름
        ConsoleUtility.ShowTitle("  Quest!!");
        ConsoleUtility.HeightPadding();

        IQuest quseList = allQuestList.questsList[ch - 1];
        Console.WriteLine($"  [{quseList.questName}]\n");
        Console.WriteLine($"{quseList.questLine}");
        ConsoleUtility.HeightPadding();
        Console.WriteLine($"  - {quseList.monsterName} {quseList.requireCount}마리 처리 \n"); //이 부분 장착에서 관리하는것도 구분해야함
        Console.WriteLine("  [ 보상 ]");
        Console.WriteLine($"  - {quseList.reward}"); //이 부분도 수정해야함
        Console.WriteLine();
        quseList.CheckQuest();

        ConsoleUtility.HeightPadding();
        if (quseList.isCompleted == false)
        {
            Console.WriteLine("  1. 수락");
            Console.WriteLine("  2. 거절");
            Console.WriteLine("  0. 나가기");
            ConsoleUtility.HeightPadding();

            int choice = ConsoleUtility.PromptMenuChoice(0, 2);
            switch (choice)
            {
                case 0:
                    QuestView();
                    break;
                case 1:
                    allQuestList.AddQuest(ch);
                    break;
                case 2:
                    allQuestList.RefuseQuest(ch);
                    break;
            }
        }
        else
        {
            Console.WriteLine("  1. 보상받기");
            Console.WriteLine("  0. 나 가 기");
            ConsoleUtility.HeightPadding();

            int choice = ConsoleUtility.PromptMenuChoice(0, 1);
            switch (choice)
            {
                case 0:
                    QuestView();
                    break;
                case 1:
                    quseList.RewardToQuest(inventory, player);
                    break;
            }
        }

    }

}