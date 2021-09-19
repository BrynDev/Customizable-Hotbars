using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DragButtonBehavior : Clickable
{
    private bool m_IsDragged = false;

    private List<ActionSlot> m_HotbarElements = new List<ActionSlot>();
    private void Start()
    {
        Transform parentTransform = transform.parent;
        int nrChildren = parentTransform.childCount;

        //store all hotbar slots that are a child to this drag button's parent (aka get every slot in this hotbar)
        for (int i = 0; i < nrChildren; ++i)
        {
            ActionSlot slot = parentTransform.GetChild(i).gameObject.GetComponent<ActionSlot>();
            //make sure to only store slots, and not the drag button
            if(slot != null)
            {           
               m_HotbarElements.Add(slot);
            }        
        }
    }

    public override void OnLeftMouseButtonDown()
    {
        //empty
    }
    public override void OnLeftMouseButtonUp()
    {
       //empty
    }

    public override void OnDragStart()
    {
        Debug.Log("Drag button hit");
        m_IsDragged = true;
    }

    public override void OnDragEnd(List<RaycastResult> dragTargets)
    {
        //drag targets unused
        Debug.Log("Drag button release");
        m_IsDragged = false;
    }

    public void Update()
    {
        if (!m_IsDragged)
        {
            return;
        }

        Vector3 previousPos = transform.position;
        transform.position = Input.mousePosition;

        Vector3 deltaPos = transform.position - previousPos;
        foreach (ActionSlot slot in m_HotbarElements)
        {          
           slot.Move(deltaPos);
        }
    }

}
