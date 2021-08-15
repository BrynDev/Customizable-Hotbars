using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Action : MonoBehaviour
{
    protected Image m_ActionIcon = null;

    protected void InitIcon()
    {
        m_ActionIcon = GetComponent<Image>();
    }

    public abstract void Execute();
}
