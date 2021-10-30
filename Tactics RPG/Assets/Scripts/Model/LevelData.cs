using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public List<Vector3> tiles;
}
// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/05/18/tactics-rpg-board-generator/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.