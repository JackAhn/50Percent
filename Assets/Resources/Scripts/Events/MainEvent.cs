using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainEvent : MonoBehaviour
{
    public void onClickStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
