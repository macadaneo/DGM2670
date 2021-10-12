using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class ImageBehavior : MonoBehaviour
{
    public object imageObj;
    private void Start()
    {
       imageObj = GetComponent<Image>();
       //UpdateUserActionsPage.raiseNoArgs += ;
    }
}
