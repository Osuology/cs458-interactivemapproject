using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public UnityEvent buttonClick;
    public Text displayText;
    public void DisplayText()
    {
        displayText.text = "tooltip text";
    }
    public void Awake()
    {
        if(buttonClick == null) { buttonClick = new UnityEvent(); }
    }
    public void OnMouseUp()
    {
        print("click");
       // DisplayText();
        buttonClick.Invoke();
    }
}
