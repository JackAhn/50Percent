using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupInstance : MonoBehaviour
{

    public static GameObject Popup;

    void Start()
    {
        Popup = GameObject.Find("Popup");
        Popup.SetActive(false);
    }

}
