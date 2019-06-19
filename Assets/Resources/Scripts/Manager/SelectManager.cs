using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{

    //발판
    private GameObject selectObj1;
    private GameObject selectObj2;
    private GameObject selectObj3;
    private GameObject selectObj4;
    private GameObject selectObj5;
    private GameObject selectObj6;

    private static SelectManager instance;

    private static PlayerManager pm;
    private static FadeController fc;
    private static int selected; //선택한 발판 번호
    private static GameObject[] selectList; //선택할 랜덤 발판 배열

    private int tileCount = 2; //만들어질 발판의 개수
    private float startX = 0f; //시작 X 위치

    void Awake()
    {

    }


    void Start()
    {

    }

    public static SelectManager getInstance()
    {
        if(instance == null)
        {
            instance = new SelectManager();
        }
        return instance;
    }

    public void createSelect() //발판 생성 메소드
    {
        setPrefab();
        if(selectList == null)
        {
            selectList = new GameObject[tileCount];
            pm = PlayerManager.getInstance();
            fc = new FadeController();
        }

        selectObj();//랜덤으로 발판 선택
        setStartX();

        float startY = -2;
        for(int i = 0; i < selectList.Length; i++)
        {
            selectList[i].gameObject.name = "Select" + (i + 1);
            Instantiate(selectList[i], new Vector3(startX, startY), selectList[i].transform.rotation);
            startX += 4f;
            if (i == 1)
            {
                startY += 5f;
                setStartX();
            }
        }
        selected = 1;
    }

    private void setPrefab()
    {
        selectObj1 = Resources.Load("Prefabs/Select1") as GameObject;
        selectObj2 = Resources.Load("Prefabs/Select2") as GameObject;
        selectObj3 = Resources.Load("Prefabs/Select3") as GameObject;
        selectObj4 = Resources.Load("Prefabs/Select4") as GameObject;
        selectObj5 = Resources.Load("Prefabs/Select5") as GameObject;
        selectObj6 = Resources.Load("Prefabs/Select6") as GameObject;
    }

    private void selectObj()  //랜덤 발판 생성
    {
        System.Random random = new System.Random();
        int i = 0;
        int index = 0;
        while(i < tileCount)
        {
            int val = random.Next(1, 6);
            switch (val)
            {
                case 1:
                    selectList[index] = selectObj1;
                    break;
                case 2:
                    selectList[index] = selectObj2;
                    break;
                case 3:
                    selectList[index] = selectObj3;
                    break;
                case 4:
                    selectList[index] = selectObj4;
                    break;
                case 5:
                    selectList[index] = selectObj5;
                    break;
                case 6:
                    selectList[index] = selectObj6;
                    break;
            }
            index++;
            i++;
        }
    }

    private void setStartX()
    {
        switch (tileCount)
        {
            case 2:
                startX = -3f;
                break;
            case 3:
                startX = -5f;
                break;
            case 4:
                startX = -7f;
                break;
            case 5:
                startX = -9f;
                break;
        }
    }

    public void moveLeft() //왼쪽으로 이동
    {
        if (selected <= tileCount && selected > 1)
        {
            selected--;
            pm.changePlayer("Select" + selected);
            //Debug.Log(selectList[selected - 1].gameObject.name);
        }
    }


    public void moveRight() //오른쪽으로 이동
    {
        if (selected >= 1 && selected < tileCount)
        {
            selected++;
            pm.changePlayer("Select" + selected);
            //Debug.Log(selectList[selected].gameObject.name);
        }
    }

    public void checkValue() //결과 확인
    {
        System.Random random = new System.Random();
        int[] val = new int[tileCount];
        int max = 0; //max 값
        int maxind = 0; //max index 값
        for (int i = 0; i < val.Length; i++)
        {
            val[i] = random.Next(1, 1000); //Select 별 랜덤 숫자 생성
            Debug.Log(i + "=" + val[i]);
        }

        for(int i = 0; i < val.Length; i++)
        {

            if (Math.Max(val[i], max) == val[i]) { //대소비교
                max = val[i];
                maxind = i + 1;
            } 
        }

        Debug.Log("selected = " + selected + ", max value = " + val[maxind - 1]);
        
        //결과 확인
        if(selected == maxind)
        {
            pm.upScore();
        }
        else
        {
            pm.downScore();
        }
    }

}
