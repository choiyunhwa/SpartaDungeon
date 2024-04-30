
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public class Inventory
{
    public List<Item> items = new List<Item>();

    private void AddItems(Item item)
    {
        items.Add(item);
    }

    /// <summary>
    /// SH - 인벤토리 리스트를 불러오는 메소드
    /// </summary>
    /// <param name="withNumber">장착 메뉴에서 번호를 보여줄 때 true값을 넘겨 받음</param>
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

    public void ToggleEquipStatus(int num)
    {
        items[num].IsEquipped = !items[num].IsEquipped;
    }

    public int CountPosion()
    {
        int idx = items.FindIndex(item => item.Ability == "물약");
        return items[idx].Count;
    }

    public void UsePotion()
    {
        int idx = items.FindIndex(item => item.Ability == "물약");
        items[idx].Count--;
    }

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

    private void EquipItem(Item choice)
    {
        int isEquipItem = items.FindIndex(item => item.IsEquipped == true && item.Ability == choice.Ability);

        if(isEquipItem != -1)
        {
            items[isEquipItem].IsEquipped = false;
            // 스탯에서 장비 수치 제거 
            choice.IsEquipped = true;
            // 스탯에서 장비 수치 추가
            Console.WriteLine("  장착했습니다.");
            Thread.Sleep(500);
        }
        else
        {
            choice.IsEquipped = true;
            Console.WriteLine("  장착했습니다.");
            Thread.Sleep(500);
        }
    }

    private void UnEquipItem(Item choice)
    {
        bool isAttack = choice.Ability == "공격력";

        //장비 착용에 따른 스탯 반영
        //if (isAttack) player.AddAtk -= choice.Attack;
        //else player.AddDef -= choice.Defense;

        choice.IsEquipped = false;
        Console.WriteLine("  장비를 해제했습니다.");
        Thread.Sleep(500);
    }
}
