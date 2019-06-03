using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    //사용자 정보 클래스
    public int id { get; private set; }
    public string userId { get; private set; }
    public string pw { get; private set; }
    public string nickname { get; private set; }

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
