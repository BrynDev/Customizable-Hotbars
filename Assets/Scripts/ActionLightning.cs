using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLightning : Action
{
    void Start()
    {
        InitIcon("Icon_Lightning");       
    }

    public override void Execute()
    {
        Debug.Log("Lightning action!");
    }
}
