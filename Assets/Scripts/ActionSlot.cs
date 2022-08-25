using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ActionSlot : Clickable
{
    [SerializeField]
    private GameObject m_CurrentAction;
    private bool m_IsActionDragged;

    void Start()
    {
        try
        {
            if (m_CurrentAction != null)
            {
                if (m_CurrentAction.GetComponent<Action>() == null)
                {
                    throw new System.Exception("Invalid GameObject specified in HotbarActionHolder script");
                }

                m_CurrentAction.transform.position = transform.position;
            }
        }
        catch(System.Exception exception)
        {
            Debug.Log(exception.Message);
        }
    }

    private void Update()
    {
        if(!m_IsActionDragged)
        {
            return;
        }

        m_CurrentAction.transform.position = Input.mousePosition;
    }

    public override void OnLeftMouseButtonDown()
    {
       //empty
    }

    public override void OnLeftMouseButtonUp()
    {
        ExecuteAction();
    }

    public override void OnDragStart()
    {
        if (m_CurrentAction == null)
        {
            return;
        }

        m_IsActionDragged = true;
    }

    public override void OnDragEnd(List<RaycastResult> dragTargets)
    {
        m_IsActionDragged = false;
        ActionSlot targetSlot = null;

        if(dragTargets.Count != 0)
        {
            foreach(RaycastResult result in dragTargets)
            {
                ActionSlot slotToCheck = result.gameObject.GetComponent<ActionSlot>();               
                if(slotToCheck != null)
                {
                    targetSlot = slotToCheck;
                    break;
                }
            }
        }

        if(targetSlot != null)
        {
            if(targetSlot.IsEmpty())
            {    
                targetSlot.SetAction(ref m_CurrentAction);
                m_CurrentAction = null;
            }
            else
            {
                //the target slot is already occupied, so swap that action with this one
                GameObject otherAction = targetSlot.GetAction();
                targetSlot.SetAction(ref m_CurrentAction);
                SetAction(ref otherAction);
            }
        }
        else
        {
            //no empty slot found, return action to this slot
            m_CurrentAction.transform.position = transform.position;
        }
    }

    public bool IsEmpty()
    {
        return (m_CurrentAction == null);
    }

    public void SetAction(ref GameObject action)
    {
        m_CurrentAction = action;    
        m_CurrentAction.transform.position = transform.position;
    }

    public void Move(Vector3 deltaPos)
    {
        transform.position += deltaPos;
        if(m_CurrentAction != null)
        {
            m_CurrentAction.transform.position += deltaPos;
        }
    }

    public ref GameObject GetAction()
    {
        return ref m_CurrentAction;
    }

    private void ExecuteAction()
    {
        if (m_CurrentAction != null)
        {
            m_CurrentAction.GetComponent<Action>().Execute();
        }
        else
        {
            Debug.Log("Empty slot pressed");
        }
    }
}
