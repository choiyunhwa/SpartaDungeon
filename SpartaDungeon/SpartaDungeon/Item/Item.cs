
public class Item
{
    public string Name { get; }
    public int Attack {  get; }
    public int Defense { get; }
    public int HP { get; }
    public string Desc { get; }
    public string Ability { get; }
    public bool IsEquipped { get; set; }
    public bool IsSelled { get; set; }
    public int Count { get; set; }

    public Item(string name, int attack, int defense, int hp, string desc, string ability, bool isEquipped, bool isSelled, int count)
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
        this.HP = hp;
        this.Desc = desc;
        this.Ability = ability;
        this.IsEquipped = false;
        this.IsSelled = false;
        this.Count = count;
    }
}
