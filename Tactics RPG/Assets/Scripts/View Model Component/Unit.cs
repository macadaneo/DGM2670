using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Tile tile { get; protected set; }
    public Directions dir;

    public void Place(Tile target)
    {
        //Make sure old tile location is not still pointing to this unit
        if (tile !=null && tile.content == gameObject)
        {
            tile.content = null;
        }
        //Link unit and tile references
        tile = target;

        if (target != null)
        {
            target.content = gameObject;
        }
    }

    public void Match()
    {
        transform.localPosition = tile.center;
        transform.localEulerAngles = dir.ToEuler();
    }
}

// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/06/08/tactics-rpg-path-finding/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.