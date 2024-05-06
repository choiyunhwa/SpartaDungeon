using System;
using System.Collections.Generic;
using System.Drawing;
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
    public List<IQuest> questsList { get; set; }

    public List<IQuest> acceptedQuestsLis = new List<IQuest>(); //현재 수락한 퀘스트

    public AllQuestList()
    {
        KillDragon = new KillDragon();

        killMinion = new KillMinion();

        killseigeMinion = new KillSeigeMinion();

        killVoidling = new KillVoidling();

        tryEquipment = new TryEquipment();

        questsList = new List<IQuest>() { KillDragon, killMinion, killseigeMinion, killVoidling, tryEquipment};
    }

    /// <summary>
    /// Load the list of quests
    /// </summary>
    /// <author> ChoiYunHwa </author>
    public void LoadQuestList()
    {
        for (int i = 0; i < questsList.Count; i++)
        {
            // 진행 중인 퀘스트인가 ?
            if (questsList[i].isAccept == true)
            {
                Console.WriteLine($"  {i + 1}. {questsList[i].questName} [진행중]");
            }
            else if (questsList[i].isCompleted == true)
            {
                if(questsList[i].isRewarded == true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"  {i + 1}. {questsList[i].questName} [완료]");
                    Console.ResetColor();
                }
                else
                    Console.WriteLine($"  {i + 1}. {questsList[i].questName} [보상받기]");
            }
            else
                Console.WriteLine($"  {i + 1}. {questsList[i].questName}");
        }
    }

    /// <summary>
    /// Add a quest into acceptedQuestsLis
    /// </summary>
    /// <param name="ch">player choice</param>
    public void AddQuest(int ch)
    {
        int num = CheckQuestList(ch);

        switch (num)
        {
            case 1:
                Console.WriteLine("  진행 중인 퀘스트입니다.");
                Thread.Sleep(500);
                break;
            case 2:
                Console.WriteLine("  완료한 퀘스트입니다.");
                Thread.Sleep(500);
                break ;
            case 0:
                acceptedQuestsLis.Add(questsList[ch - 1]);
                questsList[ch - 1].isAccept = true;
                break;
        }
    }

    /// <summary>
    /// Refuse the accepted quests
    /// </summary>
    /// <param name="ch"></param>
    public void RefuseQuest(int ch)
    {
        int num = CheckQuestList(ch);

        switch (num)
        {
            case 1:
                acceptedQuestsLis.Remove(questsList[ch - 1]);
                questsList[ch - 1].isAccept = false;
                break;
            case 0:
                break;

        }
    }

    /// <summary>
    /// Check the IsAccept
    /// </summary>
    /// <param name="ch">player choice</param>
    /// <returns>num</returns>
    public int CheckQuestList(int ch)
    {
        if (questsList[ch - 1].isAccept == true)
        {
            return 1;
        }
        else if (questsList[ch - 1].isCompleted == true)
        {
            return 2;
        }
        else
            return 0;
    }
}
