
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public class Inventory
{
    public List<Item> items = new List<Item>();

    private IPlayer player;
    private AllQuestList allQuestList;

    public Inventory(IPlayer player, AllQuestList allQuestList)
    {
        this.player = player;
        this.allQuestList = allQuestList;
    }

    /// <summary>
    /// 아이템 리스트에 아이템 추가
    /// </summary>
    /// <param name="item"></param>
    private void AddItems(Item item)
    {
        items.Add(item);
    }

    /// <summary>
    /// 인벤토리 리스트를 불러오는 메소드
    /// </summary>
    /// <param name="withNumber">장착 메뉴에서 번호를 보여줄 때 true값을 넘겨 받음</param>
    /// <author> SooHyeonKim </author>
    public void ShowInvenList(bool withNumber = false)
    {
        // 빈 인벤 리스트
        if (items.Count <= 0)
        {
            Console.WriteLine("  보유한 장비가 없습니다.");
            return;
        }

        int i = 1;
        foreach (var item in items) // 리스트 목록 출력
        {
            if (withNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"  {i}. ");
                Console.ResetColor();
            }
            else Console.Write("  - ");

            if (item.IsEquipped)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
                Console.Write(ConsoleUtility.PadRightForMixedText(item.Name, 9));
            }
            else Console.Write(ConsoleUtility.PadRightForMixedText(item.Name, 12));

            Console.Write(" | ");

            if (item.Attack != 0) Console.Write($"공격력 {(item.Attack >= 0 ? "+" : "")}{item.Attack}");
            if (item.Defense != 0) Console.Write($"방어력 {(item.Defense >= 0 ? "+" : "")}{item.Defense}");
            if (item.HP != 0) Console.Write($"방어력 {(item.HP >= 0 ? "+" : "")}{item.HP}");

            Console.Write(" | ");
            Console.Write(item.Desc);

            Console.Write(" | ");
            Console.WriteLine($"{item.Count} 개");
            i++;
        }
    }

    /// <summary>
    /// 물약 갯수 확인
    /// </summary>
    /// <returns>물약의 갯수</returns>
    /// <author> SooHyeonKim </author>
    public int CountPosion()
    {
        int idx = items.FindIndex(item => item.Ability == "물약");
        if (idx == -1)
        {
            return 0;
        }
        return items[idx].Count;
    }

    /// <summary>
    /// 포션 사용
    /// </summary>
    /// <author> SooHyeonKim </author>
    public void UsePotion()
    {
        int idx = items.FindIndex(item => item.Ability == "물약");
        items[idx].Count--;
    }

    /// <summary>
    /// 장착할 수 잇는 아이템인지 확인
    /// </summary>
    /// <param name="num">플레이어가 누른 번호</param>
    /// <author> SooHyeonKim </author>
    public void CheckEquipState(int num)
    {
        var choice = items[num];

        if(choice.Ability == "물약")
        {
            Console.WriteLine("  장착할 수 없는 장비입니다.");
            Thread.Sleep(500);
        }
        else
        {
            if (choice.IsEquipped)
            {
                UnEquipItem(choice);
            }
            else EquipItem(choice);
        }
    }

    /// <summary>
    /// 아이템 착용
    /// </summary>
    /// <param name="choice">플레이어가 선택한 번호의 리스트 값</param>
    /// <author> SooHyeonKim </author>
    private void EquipItem(Item choice)
    {
        string ability = choice.Ability;
        int isEquipItem = items.FindIndex(item => item.IsEquipped == true && item.Ability == ability);

        if(isEquipItem != -1)
        {
            items[isEquipItem].IsEquipped = false;
            // 스탯에서 장비 수치 제거 및 추가
            ChangeAddStatus(ability, isEquipItem, choice);
            choice.IsEquipped = true;
            Console.WriteLine("  장착했습니다.");
            // 퀘스트 확인
            if (allQuestList.tryEquipment.isCompleted == false)
            {
                allQuestList.tryEquipment.OnItemEquipped(choice.Name);
            }
            Thread.Sleep(500);
        }
        else
        {
            // 스탯에서 장비 수치 제거 및 추가
            if (ability == "공격력") player.AddAtk += choice.Attack;
            else player.AddDef += choice.Defense;
            choice.IsEquipped = true;
            Console.WriteLine("  장착했습니다.");
            // 퀘스트 확인
            if (allQuestList.tryEquipment.isCompleted == false)
            {
                allQuestList.tryEquipment.OnItemEquipped(choice.Name);
            }
            Thread.Sleep(500);
        }
    }

    /// <summary>
    /// 선택된 아이템 장착 해제
    /// </summary>
    /// <param name="choice">선택된 아이템</param>
    /// <author> SooHyeonKim </author>
    private void UnEquipItem(Item choice)
    {
        //장비 착용에 따른 스탯 반영
        if (choice.Ability == "공격력") player.AddAtk -= choice.Attack;
        else player.AddDef -= choice.Defense;

        choice.IsEquipped = false;
        Console.WriteLine("  장비를 해제했습니다.");
        Thread.Sleep(500);
    }

    /// <summary>
    /// 스탯에서 장비 수치 제거 및 추가
    /// </summary>
    /// <param name="ability">선택한 아이템의 능력</param>
    /// <param name="isEquipItem">선택한 아이템의 능력과 같고 장착된 아이템의 리스트 인덱스</param>
    /// <param name="choice">선택된 아이템</param>
    /// <author> SooHyeonKim </author>
    private void ChangeAddStatus(string ability, int isEquipItem, Item choice)
    {
        if (ability == "방어력")
        {
            player.AddDef = player.AddDef - items[isEquipItem].Defense + choice.Defense;
        }
        else
        {
            player.AddAtk = player.AddAtk - items[isEquipItem].Attack + choice.Attack;
        }
    }
}
