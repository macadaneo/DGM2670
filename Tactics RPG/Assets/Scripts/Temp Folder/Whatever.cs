using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Object = UnityEngine.Object;

public class Whatever : MonoBehaviour
{
    public event EventHandler <int> OnSpacePressed; //simple event
 
    private void Start(){
        
        OnSpacePressed += Testing_OnSpacePressed; // this is how we subscribe the function to the event
    }

    private void Testing_OnSpacePressed(object sender, int i)
    {
        Debug.Log("Event Fired");
    }

    private void Update(){
        //how to call an event
        if (Input.GetKeyDown(KeyCode.Space)) {
            //space pressed
          //  OnSpacePressed?.Invoke(this,EventArgs.Empty);
        }
    }
}
