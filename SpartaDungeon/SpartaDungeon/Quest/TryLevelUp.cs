﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon.Quest
{
    internal class TryLevelUp : IQuest
    {
        public string questName { get; set; }  
        public string questLine { get; set; }   
        public string reward { get; set; }        
        public bool isCompleted { get; set; }      

        public TryLevelUp()
        {
            questName = "더욱 더 강해지기";
            
            questLine = "모든 사람은 어떠한 경험을 가지며 살아간다네.\n" +
                        "그 경험을 통해 깨닫는 것이 있고, 이를 통해 더욱 단단해지지.\n" +
                        "이는 모험가에게도 마찬가지이며, 너에게도 통하는 말이겠지.\n" +
                        "경험을 쌓도록 하세. 너를 더 강해지게 해줄 것이니.\n";

            reward = "경험치";
            isCompleted = false;
        }





    }
}
