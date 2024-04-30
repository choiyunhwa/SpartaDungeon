using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon.Quest
{
    internal class KillDragon : IQuest
    {
        public string questName { get; set; }
        public string questLine { get; set; }
        public string reward { get; set; }
        public bool isCompleted { get; set; }

        public string monsterName { get; set; }       // 목표 몬스터
        public int requireCount { get; set; }       // 필요 처치 수
        public int currentCount { get; set; }       // 현재 처치 수


        public KillDragon()
        {
            questName = "던전 근처의 새끼 드래곤 처치";

            questLine = "저기요! 당신 지금 던전으로 가려고 하는 겁니까?\n" +
                        "무슨 생각입니까! 지금 던전 근처 상황을 모르시는 겁니까?\n" +
                        "이유는 모르겠지만, 새끼 드래곤이 던전 근처를 활개치며 돌아다니고 있습니다.\n" +
                        "마을에서 새끼 드래곤에게 현상금을 걸었으니, 조금만 기다리면 상급 모험가들이 토벌할 겁니다.\n" +
                        "아니면 당신도 현상금을 노리는 겁니까?\n";
            
            reward = "골드";
            monsterName = "드래곤";
            requireCount = 1;
            currentCount = 0;
            isCompleted = false;
        }

    }
}
