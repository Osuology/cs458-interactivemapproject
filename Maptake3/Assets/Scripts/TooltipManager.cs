using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TooltipManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static TooltipManager _intance;
   public TextMeshProUGUI textComponet;

    private void Awake()
    {
        if(_intance != null && _intance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _intance = this;
        }
    }
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition; 
    }

    public void SetAndShowToolTip(string message)
    {
        gameObject.SetActive(true);
        textComponet.text = message;
    }
    public void HideToolTip()
    {
        gameObject.SetActive(false);
        textComponet.text = string.Empty;
    }
}
