using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private string nearObjectName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Collider2D[] obj = Physics2D.OverlapCircleAll(gameObject.transform.position, 6f);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            for (int i = 0; i < obj.Length; i++)
            {
                Debug.Log(obj[i].name);
            }
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
