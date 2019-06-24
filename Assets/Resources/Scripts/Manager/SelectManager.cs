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
    private static int selected; //선택한 발판 번호
    private static GameObject[] selectList; //선택할 랜덤 발판 배열
    private static int tileCount = 2; //만들어질 발판의 개수

    private float startX = 0f; //시작 X 위치


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
        setTileCount();

        selectList = new GameObject[tileCount];
        if(pm == null)
            pm = PlayerManager.getInstance();

        selectObj();//랜덤으로 발판 선택
        setStartX();
        float startY = -2;

        for(int i = 0; i < selectList.Length; i++)
        {
            selectList[i].gameObject.name = "Select" + (i + 1);
            GameObject obj = Instantiate(selectList[i], new Vector3(startX, startY), selectList[i].transform.rotation);
            if (i == 0)
            {
                GameObject player = GameObject.Find("Player");
                player.transform.position = obj.transform.GetChild(1).transform.position + new Vector3(0, 2f, 0);
            }
            startX += 4f;
        }

        selected = 1;
        //pm.Initialize();
    }

    private void setPrefab() //동적 생성 전 Prefab 가져오기
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

    private void setTileCount()
    {
        if(PlayerManager.score >= 20)
        {
            tileCount = 5;
        }
        else if(PlayerManager.score >= 10)
        {
            tileCount = 4;
        }
        else if(PlayerManager.score >= 5)
        {
            tileCount = 3;
        }
        else
        {
            tileCount = 2;
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

    public bool checkValue() //결과 확인
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
            return true;
        }
        else
        {
            pm.downScore();
            return false;
        }
    }

    public void deleteObj() //발판 삭제
    {
        for(int i = 0; i < tileCount; i++)
        {
            Destroy(GameObject.Find("Select" + (i + 1) + "(Clone)"), 0f);
        }
    }

}
