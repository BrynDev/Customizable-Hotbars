using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Clickable : MonoBehaviour
{
    public abstract void OnLeftMouseButtonDown();
    public abstract void OnLeftMouseButtonUp();
}
