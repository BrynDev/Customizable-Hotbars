using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPotion : Action
{
    void Start()
    {
        InitIcon("Icon_Potion");
    }

    public override void Execute()
    {
        Debug.Log("Potion action!");
    }
}
