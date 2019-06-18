using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RegisterEvent : MonoBehaviour
{
    //RegisterScene 클릭 이벤트
    public void onClickCancelSignUp() //로그인 화면 이동 이벤트
    {
        SceneManager.LoadScene("LoginScene");
    }

    public void onClickaddUser() //회원 가입 버튼 클릭 이벤트
    {
        //TextMeshProUGUI panelTitle = GameObject.Find("PopupTitle").GetComponent<TextMeshProUGUI>();
        //TextMeshProUGUI panelText = GameObject.Find("PopupText").GetComponent<TextMeshProUGUI>();

        string[] textID = { "IDInput", "NicknameInput", "PWInput", "ConfirmPWInput" };
        string[] textVal = new string[textID.Length];
        for (int i = 0; i < textID.Length; i++)
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
        if (!textVal[2].Equals(textVal[3]))
        {
            PopupInstance.Popup.SetActive(true);
            setPopupText("Error", "Password doesn't match.");
            Debug.Log("PW 불일치");
            return;
        }
        DAO dao = DAO.getInstance();
        dao.open();
        bool val = dao.insertUser(new User(textVal[0], textVal[1], textVal[2]));
        if (val)
        {
            PopupInstance.Popup.SetActive(true);
            setPopupText("Welcome", "Welcome to 50Percent!");
        }
        else if (!val)
        {
            Debug.Log("DB Error");
        }
        dao.close();
    }

    private void setPopupText(string title, string text)
    {
        GameObject.Find("PopupTitle").GetComponent<TextMeshProUGUI>().text = title;
        GameObject.Find("PopupText").GetComponent<TextMeshProUGUI>().text = text;
    }

    private string getText(string id)
    {
        Debug.Log(id);
        TMP_InputField textmeshPro = GameObject.Find(id).GetComponent<TMP_InputField>();
        return textmeshPro.text;
    }

    public void onClickPopupExit()
    {
        //RegisterInstance.Popup.SetActive(false);
        if (GameObject.Find("PopupTitle").GetComponent<TextMeshProUGUI>().text.Equals("Welcome"))
        {
            onClickCancelSignUp();
        }
        else
        {
            PopupInstance.Popup.SetActive(false);
        }
    }
}
