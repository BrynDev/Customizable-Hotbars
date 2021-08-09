using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour
{
    private List<GraphicRaycaster> m_Raycasters = new List<GraphicRaycaster>();
    private EventSystem m_EventSystem;
   
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;    

        try
        {
            // Get the event system
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
        bool isLeftButtonDown = Input.GetMouseButtonDown(0);
        bool isLeftButtonUp = Input.GetMouseButtonUp(0);

        PointerEventData eventData = new PointerEventData(m_EventSystem);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        foreach(GraphicRaycaster raycaster in m_Raycasters)
        {
            raycaster.Raycast(eventData, results);

            foreach(RaycastResult rcResult in results)
            {
                if(isLeftButtonDown)
                {
                   rcResult.gameObject.GetComponent<Clickable>().OnLeftMouseButtonDown();
                }
                else if (isLeftButtonUp)
                {
                   rcResult.gameObject.GetComponent<Clickable>().OnLeftMouseButtonUp();
                }
               
            }
        }
    }
}
