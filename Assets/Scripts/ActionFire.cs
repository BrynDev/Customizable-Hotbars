using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFire : Action
{
    
    void Start()
    {
        InitIcon();
        m_ActionIcon.overrideSprite = Resources.Load<Sprite>("Icon_Fire");
    }

    public override void Execute()
    {
        Debug.Log("Fire action!");
    }
}
