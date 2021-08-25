using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragButtonBehavior : Clickable
{
    private bool m_IsDragged = false;

    private List<Transform> m_HotbarElements = new List<Transform>();
    private void Start()
    {
        Transform parentTransform = transform.parent;
        int nrChildren = parentTransform.childCount;

        //store all hotbar slots that are a child to this drag button's parent (aka get every slot in this hotbar)
        for (int i = 0; i < nrChildren; ++i)
        {
            Transform childObject = parentTransform.GetChild(i);
            //don't store this drag button
            if (childObject != transform)
            {
                m_HotbarElements.Add(childObject);
            }
        }
    }

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

    public override void OnDragStart()
    {
       
    }

    public override void OnDragEnd()
    {
        
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
        foreach (Transform hotbarSlot in m_HotbarElements)
        {
            hotbarSlot.transform.position += deltaPos;
        }
    }

}
