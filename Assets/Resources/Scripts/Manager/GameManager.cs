using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        time = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time != 0f)
        {
            time -= Time.deltaTime;
            timerText.text = string.Format("{0:N2}", time);
        }
    }

}
