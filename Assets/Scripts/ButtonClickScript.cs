using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickScript : MonoBehaviour
{
    
    //public Text keyText;
    public int buttonID = -1;
    public void OnClick()
    {
        ;
        Key.SetKeyTo(buttonID);
        Debug.Log(KeyLibrary.AllKeys);
        //keyText.text = "Current key: " + Key.CircleOfFifths[buttonID];

    }

    void Start()
    {
        //keyText = GameObject.Find("CurrentKeyText").GetComponent<Text>();
    }
}