using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragButtonBehavior : Clickable
{
    private bool m_IsDragged = false;
    
    public override void OnLeftMouseButtonDown()
    {
        Debug.Log("Drag button hit");
        m_IsDragged = true;
    }

    public override void OnLeftMouseButtonUp()
    {
        Debug.Log("Drag button release");
        m_IsDragged = false;
    }

    public void Update()
    {
        if(!m_IsDragged)
        {
            return;
        }

        transform.position = Input.mousePosition;
    }

}
