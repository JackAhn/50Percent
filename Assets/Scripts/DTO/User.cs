using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    //사용자 정보 클래스
    private int id { get; set; }
    private string userId { get; set; }
    private string pw { get; set; }
    private string nickname { get; set; }

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
