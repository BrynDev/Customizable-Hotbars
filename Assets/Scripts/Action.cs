using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Action : MonoBehaviour
{
    private Image m_ActionIcon = null;

    protected abstract void Execute();
}
