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

                //move into place
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
        GameObject targetSlot = null;

        //check if anything was hit
        if(dragTargets.Count != 0)
        {
            //search all targets for an empty ActionSlot
            foreach(RaycastResult result in dragTargets)
            {
                ActionSlot slotToCheck = result.gameObject.GetComponent<ActionSlot>();
                //could possibly be combined into one if-and check,
                //but I want to put the null check by itself to make sure IsEmpty doesn't get called on a null object
                if(slotToCheck == null)
                {
                    continue;
                }
                if(slotToCheck.IsEmpty())
                {
                    targetSlot = result.gameObject;
                    break;
                }
            }
        }

      
        if(targetSlot != null)
        {
            //an empty slot was successfully found       
            GameObject actionToMove = m_CurrentAction;         
            targetSlot.GetComponent<ActionSlot>().SetAction(ref actionToMove);
            m_CurrentAction = null;
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
