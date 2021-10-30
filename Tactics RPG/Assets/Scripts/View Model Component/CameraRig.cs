using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public float speed = 3f;
    public Transform follow;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        if (follow)
        {
            _transform.position = Vector3.Lerp(_transform.position,
                follow.position, speed * Time.deltaTime);
        }
    }
}

// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/06/01/tactics-rpg-state-machine/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.