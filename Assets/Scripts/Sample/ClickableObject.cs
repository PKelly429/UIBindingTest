using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    public abstract void OnClick();
}