public interface IPlayer
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; set; }
    public float Atk { get; set; }
    public float AddAtk { get; set; }
    public float Def { get; set; }
    public float AddDef { get; set; }
    public int MaxHp { get; set; }
    public int CurrentHp { get; set; }
    public int MaxMP { get; set; }
    public int CurrentMP { get; set; }
    public int Gold { get; set; }
    public int Experience { get; set; }
    public int CurrentDungenon {  get; set; }
    public void GetGold(int coin);
    public void LevelUp();
    public void GainExperience(int exp);
    public void jobskills();
    public void UsePotion();

    public EAttackInfor eAttackInfor { get; set; }
    public int Attack();

    //public class Player
    //{
    //    public Inventory inventory = new Inventory();
    //    public List<Item> equipedItems = new List<Item>();
    //}
}
