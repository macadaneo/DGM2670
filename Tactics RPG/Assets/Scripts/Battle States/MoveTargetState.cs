using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class MoveTargetState : BattleState
{
    protected override void OnMove(object sender, InfoEventArgs<Point> e)
    {
       SelectTile(e.info + pos);
    }
}

// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/06/01/tactics-rpg-state-machine/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.