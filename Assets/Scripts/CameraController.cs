using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target = null;
    [SerializeField]
    private Transform m_Player = null;
    [SerializeField]
    private float m_CameraSpeed = 1;

    private float m_TotalMouseX = 0;
    private float m_TotalMouseY = 0;
    

    void Update()
    {
        if(!Input.GetMouseButton(1))
        {
            return;
        }
        m_TotalMouseX += Input.GetAxis("MouseX") * m_CameraSpeed;
        m_TotalMouseY -= Input.GetAxis("MouseY") * m_CameraSpeed;
        m_TotalMouseY = Mathf.Clamp(m_TotalMouseY, -75, 60);

        transform.LookAt(m_Target);
        m_Target.rotation = Quaternion.Euler(m_TotalMouseY, m_TotalMouseX, 0);
        m_Player.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    
}
