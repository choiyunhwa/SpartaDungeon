using SpartaDungeon.Quest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AllQuestList
{
    KillDragon KillDragon { get; set; }
    KillMinion killMinion { get; set; }
    KillSeigeMinion killseigeMinion { get; set; }
    KillVoidling killVoidling { get; set; }
    TryEquipment tryEquipment { get; set; }
    TryLevelUp tryLevelUp { get; set; }
    List<IQuest> questsList { get; set; }

    public AllQuestList()
    {
        KillDragon = new KillDragon();

        killMinion = new KillMinion();

        killseigeMinion = new KillSeigeMinion();

        killVoidling = new KillVoidling();

        tryEquipment = new TryEquipment();

        tryLevelUp = new TryLevelUp();

        questsList = new List<IQuest>() { KillDragon, killMinion, killseigeMinion, killVoidling, tryEquipment, tryLevelUp};
    }

}
