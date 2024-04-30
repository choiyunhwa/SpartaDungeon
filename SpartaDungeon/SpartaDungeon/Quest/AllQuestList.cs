using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AllQuestList
{
    public KillDragon KillDragon { get; set; }
    public KillMinion killMinion { get; set; }
    public KillSeigeMinion killseigeMinion { get; set; }
    public KillVoidling killVoidling { get; set; }
    public TryEquipment tryEquipment { get; set; }
    public TryLevelUp tryLevelUp { get; set; }
    public List<IQuest> questsList { get; set; }

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
