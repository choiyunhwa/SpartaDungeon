using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IQuest
{
    string questName { get; set; }      // 퀘스트 이름
    string questLine { get; set; }      // 퀘스트 대사
    string reward { get; set; }         // 퀘스트 보상
    bool isCompleted { get; set; }      // 퀘스트 완료 여부

    // 조건 확인 메소드

    // 퀘스트 완료 메소드
}
