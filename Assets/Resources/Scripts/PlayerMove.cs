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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
            sm.moveLeft();

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
            sm.moveRight();
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            sm.checkValue();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
