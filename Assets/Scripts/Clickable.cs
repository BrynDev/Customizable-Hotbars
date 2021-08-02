using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract public class Clickable : MonoBehaviour
{
    private EventSystem m_EventSystem = null;
    private GraphicRaycaster m_Raycaster = null;

    public void Start()
    {    
        try
        {
            // Get the event system
            m_EventSystem = EventSystem.current;
            if (m_EventSystem == null)
            {
                throw new System.Exception("No event system found in current scene");
            }

            // Get the canvas' graphics raycaster
            // In case of nested objects where the canvas is several layers up, recursively check parents until a raycaster is found
            GameObject parentToCheck = transform.parent.gameObject;
            while (parentToCheck != null && m_Raycaster == null)
            {
                m_Raycaster = parentToCheck.GetComponent<GraphicRaycaster>();
                parentToCheck = parentToCheck.transform.parent.gameObject;
            }
            // If a raycaster is not found, throw exception
            if(m_Raycaster == null)
            {
                throw new System.Exception("No canvas found in clickable object's parent structure");
            }
        }
        catch (System.Exception exception)
        {
            Debug.Log(exception.Message);
        } 
    }

  
    public void Update()
    {
        //todo: make a "click controller", so that input checking can happen once per frame instead of on each clickable object
        if(!Input.GetMouseButtonDown(0))
        {
            return;
        }

        PointerEventData eventData = new PointerEventData(m_EventSystem);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(eventData, results);

        foreach(RaycastResult result in results)
        {
            OnClick();
        }
    }

    public abstract void OnClick();
}
