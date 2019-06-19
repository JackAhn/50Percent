using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    private static PlayerManager instance;
    private static int score;

    private static TextMeshProUGUI scoreText;


    public static PlayerManager getInstance()
    {
        if (instance == null)
            instance = new PlayerManager();
        return instance;
    }


    public void Initialize() //Select1 발판에 Player 위치 설정
    {
        GameObject player = GameObject.Find("Player");
        player.transform.position = GameObject.Find("Select1(Clone)").gameObject.transform.GetChild(1).transform.position;
        player.transform.position = new Vector3(player.transform.position.x, 0.5f);

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void changePlayer(String tagName)
    {
        GameObject player = GameObject.Find("Player");
        GameObject select = GameObject.Find(tagName + "(Clone)");
        player.transform.position = select.gameObject.transform.GetChild(1).transform.position;
        player.transform.position = new Vector3(player.transform.position.x, 0.2f);
    }

    public void upScore()
    {
        score++;
        scoreText.SetText("Score : " + score);
        Debug.Log(score);
    }

    public void downScore()
    {
        if(score != 0)
            score--;
        scoreText.SetText("Score : " + score);
        Debug.Log(score);
    }

}
