using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoginEvent : MonoBehaviour
{

    public void onClickLogin()
    {
        string[] textID = { "IDInput", "PWInput" };
        string[] textVal = new string[textID.Length];
        for(int i = 0; i < textID.Length; i++)
        {
            textVal[i] = getText(textID[i]);
            if (textVal[i].Equals("") || textVal[i] == null)
            {
                //Panel 추가시켜 팝업창 띄우게 하기
                PopupInstance.Popup.SetActive(true);
                setPopupText("Error", "A space exists");
                Debug.Log("공백");
                return;
            }
        }
        DAO dao = DAO.getInstance();
        dao.open();
        User val = dao.checkUser(textVal[0], textVal[1]);
        if (val.id != 0)
        {
            //유저 데이터 저장
            MainManager.userData = val;
            MainManager.rankData = new Rank(val.nickname, 0);

            //MainScene 이동
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            //에러 메시지 출력
            setPopupText("Error", "id and pw do not match.");
        }
        dao.close();
    }

    //LoginScene 클릭 이벤트
    public void onClickSignUP() //회원 가입 이동 버튼
    {
        SceneManager.LoadScene("RegisterScene");
    }

    public void onClickExit() //게임 종료 버튼
    {
        Application.Quit();
    }

    public void onClickPopupExit()
    {
        //RegisterInstance.Popup.SetActive(false);
        if (GameObject.Find("PopupTitle").GetComponent<TextMeshProUGUI>().text.Equals("Welcome"))
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            PopupInstance.Popup.SetActive(false);
        }
    }

    private void setPopupText(string title, string text)
    {
        PopupInstance.Popup.SetActive(true);
        GameObject.Find("PopupTitle").GetComponent<TextMeshProUGUI>().text = title;
        GameObject.Find("PopupText").GetComponent<TextMeshProUGUI>().text = text;
    }

    private string getText(string id)
    {
        TMP_InputField textmeshPro = GameObject.Find(id).GetComponent<TMP_InputField>();
        return textmeshPro.text;
    }

}
