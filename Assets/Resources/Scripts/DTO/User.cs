using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    //사용자 정보 클래스
    public int id { get; set; }
    public string userId { get; set; }
    public string pw { get; set; }
    public string nickname { get; set; }

    public User()
    {

    }

    public User(string userId, string pw, string nickname)
    {
        this.userId = userId;
        this.pw = pw;
        this.nickname = nickname;
    }

    public User(User user)
    {
        this.id = user.id;
        this.userId = user.userId;
        this.pw = user.pw;
        this.nickname = user.pw;
    }


}
