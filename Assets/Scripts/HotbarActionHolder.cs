using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarActionHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject m_CurrentAction;

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
}
