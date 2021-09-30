using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFire : Action
{
    void Start()
    {
        InitIcon("Icon_Fire");
        GetPlayer();
    }

    public override void Execute()
    {
        Debug.Log("Fire action!");
    }
}
