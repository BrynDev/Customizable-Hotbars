using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

abstract public class Clickable : MonoBehaviour
{
    public abstract void OnLeftMouseButtonDown();
    public abstract void OnLeftMouseButtonUp();
    public abstract void OnDragStart();
    public abstract void OnDragEnd(List<RaycastResult> dragTargets);
}
