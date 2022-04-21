using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;
using UnityEngine.Events;

namespace UnityEvents.Test1 
{
    public class Demo : MonoBehaviour
    {
        public static UnityEvent testEvent = new UnityEvent();
        public int listenerCount = 250;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Test();
            }
        }

        void Test()
        {
            Listener[] listeners = new Listener[listenerCount];
            for (int i = 0; i < listenerCount; i++)
            {
                listeners[i] = new Listener();
                listeners[i].Enable();
            }
            
            testEvent.Invoke();

            for (int i = 0; i < listeners.Length; i++)
            {
                listeners[i].Disable();
            }
        }
    }

    public class Listener
    {
        public void Enable()
        {
            Demo.testEvent.AddListener(OnTest);
        }

        public void Disable()
        {
            Demo.testEvent.RemoveListener(OnTest);
        }

        void OnTest()
        {
            
        }        
    }
}
