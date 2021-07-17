using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_Camera = transform.GetChild(3);
    }

    // Update is called once per frame
    void Update()
    {
       float movementForward = Input.GetAxis("Forward");
       float movementRight = Input.GetAxis("Right");
       Vector3 totalMovement = new Vector3(movementRight, 0.0f, movementForward) * m_MoveSpeed * Time.deltaTime;
       transform.Translate(totalMovement);

       m_TotalMouseX += Input.GetAxis("MouseX") * m_CameraSpeed;
       m_TotalMouseY -= Input.GetAxis("MouseY") * m_CameraSpeed;
       Mathf.Clamp(m_TotalMouseY, 10, 90);
        m_Camera.LookAt(transform.position);
        m_Camera.rotation = Quaternion.Euler(m_TotalMouseY, m_TotalMouseX, 0);

    }

    [SerializeField]
    private float m_MoveSpeed = 1;
    [SerializeField]
    private float m_CameraSpeed = 1;

    private Transform m_Camera;
    private float m_TotalMouseX;
    private float m_TotalMouseY;
}
