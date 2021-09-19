using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLightning : Action
{
    void Start()
    {
        InitIcon();
        m_ActionIcon.overrideSprite = Resources.Load<Sprite>("Icon_Lightning");
    }

    public override void Execute()
    {
        Debug.Log("Lightning action!");
    }
}
