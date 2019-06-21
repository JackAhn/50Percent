using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static User userData;
    public static Rank rankData;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        DAO dao = DAO.getInstance();
        dao.open();
        List<Rank> top5 = dao.getTop5Rank();
        setRankData(top5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setRankData(List<Rank> top5)
    {
        for(int i = 0; i < top5.Count; i++)
        {
            GameObject.Find("Top" + (i + 1) + "Text").GetComponent<TextMeshProUGUI>().text = top5[i].nickname;
            GameObject.Find("Top" + (i + 1) + "ScoreText").GetComponent<TextMeshProUGUI>().text = top5[i].score + "";
        }
    }
}
