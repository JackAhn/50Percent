using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerManager playerManager;
    private SelectManager selectManager;
    private int score;

    void Awake()
    {
        score = 0;

        playerManager = PlayerManager.getInstance();
        selectManager = SelectManager.getInstance();

        selectManager.createSelect();
        playerManager.InitializePlayer();
        
    }

    // Start is called before the first frame update
    void Start()
    {
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }

    public void upScore()
    {
        score++;
    }

    public void downScore()
    {
        score--;
    }

}
