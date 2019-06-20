using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rank : MonoBehaviour
{
    //게임 플레이 결과를 알려주는 클래스

    public int id { get; set; }
    public string nickname { get; set; }
    public int score { get; set; }

    
    public Rank(string nickname, int score)
    {
        this.nickname = nickname;
        this.score = score;
    }
}
