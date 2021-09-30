using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Action : MonoBehaviour
{
    protected Image m_ActionIcon = null;
    protected GameObject m_Player = null;

    protected void InitIcon(string iconName)
    {
        m_ActionIcon = GetComponent<Image>();
        m_ActionIcon.overrideSprite = Resources.Load<Sprite>(iconName);
    }

    protected void GetPlayer()
    {
        try
        {
            m_Player = GameObject.FindGameObjectWithTag("Player");
            if (m_Player == null)
            {
                m_Player = new GameObject();
                throw new System.Exception("No object with tag Player found in scene. Setting m_Player to empty GameObject.");
            }
        }
        catch (System.Exception exception)
        {
            Debug.Log(exception.Message);
        }
    }

    public abstract void Execute();
}
