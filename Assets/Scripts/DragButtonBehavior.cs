using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragButtonBehavior : Clickable
{
    public override void OnClick()
    {
        Debug.Log("Drag button hit");
    }
   
}
