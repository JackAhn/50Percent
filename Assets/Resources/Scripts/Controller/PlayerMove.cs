using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerManager pm;
    private SelectManager sm;
    private List<GameObject> nearObject = new List<GameObject>(); //근처 발판

    // Start is called before the first frame update
    void Start()
    {
        pm = PlayerManager.getInstance();
        sm = SelectManager.getInstance();
    }

    // Update is called once per frame
    void Update()
    {

        GameObject player = GameObject.Find("Player");
        nearObject = null;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
            sm.moveLeft();

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
            sm.moveRight();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            sm.checkValue();
            StartCoroutine(CoFadeOut(1f));
        }
    }

    IEnumerator CoFadeOut(float fadeOutTime) //투명하게 변경
    {
        SpriteRenderer sr = GameObject.Find("Fader").GetComponent<SpriteRenderer>();
        Color color = sr.color;

        //빨간색 불투명하게 설정
        color.a = 1f;
        sr.color = color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / fadeOutTime;
            sr.color = color;

            if (color.a <= 0f)
                color.a = 0f;

            yield return null;
        }
        sr.color = color;
    }
}
