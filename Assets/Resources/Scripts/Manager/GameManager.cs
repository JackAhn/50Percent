using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private PlayerManager playerManager;
    private SelectManager selectManager;
    private float time;
    private TextMeshProUGUI timerText;

    void Awake()
    {
        playerManager = PlayerManager.getInstance();
        selectManager = SelectManager.getInstance();

        selectManager.createSelect();
        playerManager.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
        time = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0f)
        {
            time -= Time.deltaTime;
            timerText.text = string.Format("{0:N2}", time);
        }
        else //60초 종료 시
        {
            PlayerManager.isMove = false;
            timerText.text = string.Format("{0:N2}", 0);
            StartCoroutine(CoFadeIn(1f));
            SceneManager.LoadScene("ResultScene");
        }

    }

    IEnumerator CoFadeIn(float fadeOutTime) //불투명하게 변경
    {
        Image im = GameObject.Find("Fader").GetComponent<Image>();

        //검은색으로 설정
        Color black = new Color(0, 0, 0, 0);
        im.color = black;
        Color color = im.color;

        //불투명하게 설정
        color.a = 0f;
        im.color = color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime / fadeOutTime;
            im.color = color;

            if (color.a >= 1f)
                color.a = 1f;

            yield return null;
        }
        im.color = color;
    }

}
