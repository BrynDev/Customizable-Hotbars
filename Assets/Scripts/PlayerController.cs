using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_MoveSpeed = 1;
    
    void Update()
    {
       float movementForward = Input.GetAxis("Forward");
       float movementRight = Input.GetAxis("Right");
       Vector3 totalMovement = new Vector3(movementRight, 0.0f, movementForward) * m_MoveSpeed * Time.deltaTime;
       transform.Translate(totalMovement);
    }

    
}
