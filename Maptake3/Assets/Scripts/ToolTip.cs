using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    // Start is called before the first frame update
    public string message;
    private void OnMouseEnter()
    {
        TooltipManager._intance.SetAndShowToolTip(message);
    }
    private void OnMouseExit()
    {
        TooltipManager._intance.HideToolTip();
    }
}
