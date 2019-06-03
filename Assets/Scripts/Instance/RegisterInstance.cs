using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterInstance : MonoBehaviour
{
    private static RegisterInstance instance;
    public static GameObject Popup;

    void Start()
    {
        Popup = GameObject.Find("Popup");
        Popup.SetActive(false);
    }

    public static RegisterInstance getInstance()
    {
        if (instance == null)
        {
            instance = new RegisterInstance();
        }
        return instance;
    }
}
