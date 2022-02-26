using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITestImplementation : ITestInterface
{
    public void test_function()
    {
        throw new System.NotImplementedException();
    }

    public int AmmoCount
    {
        get
        {
            return _AmmoCount;
        }
        set
        {
            _AmmoCount = value;
        }
    }
    private int _AmmoCount;
}
