using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
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
        if (PlayerManager.isMove)
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
                if (!sm.checkValue())
                    StartCoroutine(CoFadeOut(0.4f));
                sm.deleteObj();
                sm.createSelect();
            }
        }
    }

    IEnumerator CoFadeOut(float fadeOutTime) //투명하게 변경
    {
        Image im = GameObject.Find("Fader").GetComponent<Image>();
        Color color = im.color;

        //빨간색 불투명하게 설정
        color.a = 0.6f;
        im.color = color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / fadeOutTime;
            im.color = color;

            if (color.a <= 0f)
                color.a = 0f;

            yield return null;
        }
        im.color = color;
    }

}
