using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_MoveSpeed = 1;

    private Rigidbody m_RigidBody = null;
    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
       float movementForward = Input.GetAxis("Forward");
       float movementRight = Input.GetAxis("Right");      
       Vector3 movementDirection = movementForward * transform.forward + movementRight * transform.right;
       movementDirection.Normalize();
       Vector3 movementVelocity = movementDirection * m_MoveSpeed * Time.deltaTime;
       m_RigidBody.velocity = movementVelocity;
    }

    
}
