using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum EScreenView
{
    BASIC,
    MAIN_BATTLE,
    SKILL_BATTLE,
    ENEMY_BATTLE,
    QUEST
}

public enum EAttackInfor
{
    BASIC, //기본 공격
    NONE,  //공격 실패
    CRITICAL, //치명타 공격
}
