﻿public interface IPlayer
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
    public int MaxMana { get; set; }
    public int CrrentMana { get; set; }
    public int Gold { get; set; }
    public int Experience { get; set; }

    public void GetGold(int coin);
    public void LevelUp();
    public void GainExperience(int exp);

}