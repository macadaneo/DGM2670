using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class LayoutAnchor : MonoBehaviour
{
    private void Awake()
    {
        myRT = transform as RectTransform;
        parentRT = transform.parent as RectTransform;
        if (parentRT == null)
        {
            Debug.LogError("This component requires a RectTransform parent to work.", gameObject);
        }
    }

    Vector2 GetPosition(RectTransform rt, TextAnchor anchor)
    {
        Vector2 retValue = Vector2.zero;

        switch (anchor)
        {
            case TextAnchor.LowerCenter:
            case TextAnchor.MiddleCenter: 
            case TextAnchor.UpperCenter:
                retValue.x += rt.rect.width * 0.5f;
                break;
        }
    } 
}
