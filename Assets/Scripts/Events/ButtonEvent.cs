using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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

    //RegisterScene 클릭 이벤트
    public void onClickCancelSignUp() //회원 가입 취소 버튼
    {
        SceneManager.LoadScene("LoginScene");
    }

    public void onClickaddUser() //회원 가입 버튼
    {
        GameObject panel = GameObject.Find("Popup");
        //TextMeshProUGUI panelTitle = GameObject.Find("PopupTitle").GetComponent<TextMeshProUGUI>();
        //TextMeshProUGUI panelText = GameObject.Find("PopupText").GetComponent<TextMeshProUGUI>();

        string[] textID = { "IDInput", "NicknameInput", "PWInput", "ConfirmInput" };
        string[] textVal = new string[textID.Length];
        for (int i = 0; i < textID.Length; i++)
        {
            textVal[i] = getText(textID[i]);
            if (textVal[i].Equals("") || textVal[i] == null)
            {
                //Panel 추가시켜 팝업창 띄우게 하기
                panel.gameObject.SetActive(true);
                GameObject.Find("PopupTitle").GetComponent<TextMeshProUGUI>().text = "Error";
                GameObject.Find("PopupText").GetComponent<TextMeshProUGUI>().text = "A space exists.";
                Debug.Log("공백");
                return;
            }
        }
        if (!textVal[2].Equals(textVal[3]))
        {

            Debug.Log("PW 불일치");
            return;
        }
        DAO dao = DAO.getInstance();
        dao.open();
        bool val = dao.insertUser(new User(textVal[0], textVal[1], textVal[2]));
        if (val)
        {

        }
        else if (!val)
        {
            Debug.Log("DB Error");
        }
    }

    private string getText(string id)
    {
        Debug.Log(id);
        TMP_InputField textmeshPro = GameObject.Find(id).GetComponent<TMP_InputField>();
        return textmeshPro.text;
    }

    public void onClickSignUpExit()
    {
        GameObject panel = GameObject.Find("Popup");
        panel.gameObject.SetActive(false);
    }
}
