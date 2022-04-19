using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.UnitTesting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Events.Test1
{
    public class Demo : MonoBehaviour
    {
        public static event EventHandler testEvent;
        public int listenerCount = 250;

        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Test();
            }
        }

        void Test()
        {
            Listener[] listeners = new Listener[listenerCount];
            for (int i = 0; i < listenerCount; ++i)
            {
                listeners[i] = new Listener();
                listeners[i].Enable();
            }

            if (testEvent != null)
            {
                testEvent(this, EventArgs.Empty);
            }

            for (int i = 0; i < listeners.Length; i++)
            {
                listeners[i].Disable();
            }
        }

        public class Listener
        {
            public void Enable()
            {
                Demo.testEvent += OnTest;
            }

            public void Disable()
            {
                Demo.testEvent -= OnTest;
            }

            void OnTest(object sender, EventArgs info)
            {

            }
        }
    }

}