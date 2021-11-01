using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DirectionsExtensions
{
   public static Directions GetDirection(this Tile t1, Tile t2)
   {
      if (t1.pos.y < t2.pos.y)
      {
         return Directions.North;
      }

      if (t1.pos.y < t2.pos.x)
      {
         return Directions.East;
      }

      if (t1.pos.y > t2.pos.y)
      {
         return Directions.South;
      }

      return Directions.West;
   }

   public static Vector3 ToEuler(this Directions d)
   {
      return new Vector3(0, (int)d * 90, 0);
   }
}


// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/06/08/tactics-rpg-path-finding/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.