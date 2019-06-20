using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoFadeOut(1f));
        GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = "Your score is " + PlayerManager.score;
        GameObject.Find("SuccessText").GetComponent<TextMeshProUGUI>().text = "Success : " + PlayerManager.success;
        GameObject.Find("FailText").GetComponent<TextMeshProUGUI>().text = "Fail : " + PlayerManager.fail;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoFadeOut(float fadeOutTime) //투명하게 변경
    {
        Image im = GameObject.Find("Fader").GetComponent<Image>();
        Color color = im.color;

        //검은색 불투명하게 설정
        color.a = 1f;
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
        im.enabled = false;
    }
}
