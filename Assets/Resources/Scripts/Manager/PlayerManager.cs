using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private static PlayerManager instance;

    public static PlayerManager getInstance()
    {
        if (instance == null)
            instance = new PlayerManager();
        return instance;
    }


    public void InitializePlayer() //Select1 발판에 Player 위치 설정
    {
        GameObject player = GameObject.Find("Player");
        player.transform.position = GameObject.Find("Select1(Clone)").gameObject.transform.GetChild(1).transform.position;
        player.transform.position = new Vector3(player.transform.position.x, 0.5f);
    }

    public void changePlayer(String tagName)
    {
        GameObject player = GameObject.Find("Player");
        GameObject select = GameObject.Find(tagName + "(Clone)");
        player.transform.position = select.gameObject.transform.GetChild(1).transform.position;
        player.transform.position = new Vector3(player.transform.position.x, 0.2f);
    }

}
