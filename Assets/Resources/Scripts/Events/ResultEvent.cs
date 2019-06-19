using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultEvent : MonoBehaviour
{
    public void onClickOK()
    {
        SceneManager.LoadScene("MainScene");
    }
}
