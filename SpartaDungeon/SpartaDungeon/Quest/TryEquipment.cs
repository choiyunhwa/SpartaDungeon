using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class TryEquipment : IQuest
{
    public string questName { get; set; }      // 퀘스트 이름
    public string questLine { get; set; }      // 퀘스트 대사
    public string reward { get; set; }         // 퀘스트 보상
    public bool isCompleted { get; set; }      // 퀘스트 완료 여부

    public TryEquipment()
    {
        questName = "장비를 장착해보자";
        
        questLine = "자네! 장비는 제대로 착용하고 있는가?\n" + 
                    "모험가에게 장비는 목숨과도 같다네!\n" + 
                    "모험가가 장비를 착용하지 않는 것은 죽겠다는 거와 다름없지!\n" + 
                    "장비가 생기는 대로 착용해 보는 것을 권한다네!";
        
        reward = "경험치";
        isCompleted = false;
    }




}

