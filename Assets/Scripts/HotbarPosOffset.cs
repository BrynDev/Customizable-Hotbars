using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarPosOffset : MonoBehaviour
{
    // Since the position of the hotbar is defined in the prefab, this script is used to easily assign a screen space position offset from the editor,
    // so that multiple hotbars dont overlap perfectly when the game starts.


    [SerializeField]
    private Vector3 m_Offset;
    void Awake()
    {
        Canvas canvas = GetComponentInChildren<Canvas>();
        int nrChildren = canvas.transform.childCount;
        for(int i = 0; i < nrChildren; ++i)
        {
            canvas.transform.GetChild(i).transform.position += m_Offset;
        }
    }
}
