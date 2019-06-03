using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoginEvent : MonoBehaviour
{

    //LoginScene 클릭 이벤트
    public void onClickSignUP() //회원 가입 이동 버튼
    {
        SceneManager.LoadScene("RegisterScene");
    }

    public void onClickExit() //게임 종료 버튼
    {
        Application.Quit();
    }

    
}
