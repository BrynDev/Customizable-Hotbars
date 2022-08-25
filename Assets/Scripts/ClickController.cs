using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour
{
    private List<GraphicRaycaster> m_Raycasters = new List<GraphicRaycaster>();
    private EventSystem m_EventSystem;
    private Vector3 m_ClickStartPos;
    private float m_MinDragDelta = 0.3f;
    private Clickable m_CurrentClickable = null;
    enum ClickState
    {
        none,
        leftButtonDown,
        dragging
    }
    ClickState m_CurrentClickState = ClickState.none;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        try
        {
            m_EventSystem = EventSystem.current;
            if (m_EventSystem == null)
            {
                throw new System.Exception("No event system found in current scene");
            }
        }
        catch (System.Exception exception)
        {
            Debug.Log(exception.Message);
        }

        GameObject[] canvasObjects = GameObject.FindGameObjectsWithTag("InteractCanvas");
        foreach (GameObject canvas in canvasObjects)
        {
            m_Raycasters.Add(canvas.GetComponent<GraphicRaycaster>());
        }
    }

    public void Update()
    {
        List<RaycastResult> raycastResults;
        switch (m_CurrentClickState)
        {
            case ClickState.none:
                if (!Input.GetMouseButtonDown(0))
                {
                    break;
                }
         
                raycastResults = DoRaycasts();
                if (raycastResults.Count != 0)
                {
                    m_CurrentClickable = raycastResults[0].gameObject.GetComponent<Clickable>(); //handle the first object hit
                    m_CurrentClickable.OnLeftMouseButtonDown();
                    m_ClickStartPos = Input.mousePosition; //current mouse pos
                    m_CurrentClickState = ClickState.leftButtonDown;
                }

                break;
            case ClickState.leftButtonDown:             
                if (Input.GetMouseButtonUp(0))
                {
                    m_CurrentClickable.OnLeftMouseButtonUp();
                    m_CurrentClickable = null;
                    m_CurrentClickState = ClickState.none;
                    break;
                }

                if (Vector3.Distance(m_ClickStartPos, Input.mousePosition) > m_MinDragDelta)
                {
                    m_CurrentClickable.OnDragStart();
                    m_CurrentClickState = ClickState.dragging;
                }

                break;
            case ClickState.dragging:
                if (!Input.GetMouseButtonUp(0))
                {
                    break;
                }

                //button was released, dragging has ended
                raycastResults = DoRaycasts();
                m_CurrentClickable.OnDragEnd(raycastResults);
                m_CurrentClickable = null;
                m_CurrentClickState = ClickState.none;

                break;
            default:
                break;
        }
    }

    private List<RaycastResult> DoRaycasts()
    {
        PointerEventData eventData = new PointerEventData(m_EventSystem);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        foreach (GraphicRaycaster raycaster in m_Raycasters)
        {
            raycaster.Raycast(eventData, results);
        }

        return results;
    }
}
