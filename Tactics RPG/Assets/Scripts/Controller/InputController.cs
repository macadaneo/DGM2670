using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputController : MonoBehaviour
{
    public static event EventHandler<InfoEventArgs<Point>> moveEvent;
    public static event EventHandler<InfoEventArgs<int>> fireEvent; 
    
    private Repeater _hor = new Repeater("Horizontal");
    private Repeater _ver = new Repeater("Vertical");
    private string[] _buttons = new string[] { "Fire1", "Fire2", "Fire3" };
    void Update()
    {
        int x = _hor.Update();
        int y = _ver.Update();
        if (x != 0 || y != 0)
        {
            if (moveEvent != null)
            {
                moveEvent(this, new InfoEventArgs<Point>(new Point(x, y)));
            }
        }

        for (int i = 0; i < 3; ++i)
        {
            if (Input.GetButtonUp(_buttons[i]))
            {
                if (fireEvent != null)
                {
                    fireEvent(this, new InfoEventArgs<int>(i));
                }
            }
        }
    }
}

class Repeater
{
    private const float threshold = 0.5f;
    private const float rate = 0.25f;
    private float _next;
    private bool _hold;
    private string _axis;

    public Repeater(string axisName)
    {
        _axis = axisName;
    }

    public int Update()
    {
        int retValue = 0;
        int value = Mathf.RoundToInt(Input.GetAxisRaw(_axis));

        if (value != 0)
        {
            if (Time.time > _next)
            {
                retValue = value;
                _next = Time.time + (_hold ? rate : threshold);
                _hold = true;
            }
        }
        else
        {
            _hold = false;
            _next = 0;
        }

        return retValue;
    }
}



// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/05/24/user-input-controller/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.