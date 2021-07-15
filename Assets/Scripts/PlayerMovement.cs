using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Forward"))
       {
            
            transform.Translate(Input.GetAxis("Forward") * transform.forward * m_MoveSpeed * Time.deltaTime);
       }
       
    }

    [SerializeField]
    private float m_MoveSpeed;
}
