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
   
   public static Directions GetDirection (this Point p)
   {
      if (p.y > 0)
         return Directions.North;
      if (p.x > 0)
         return Directions.East;
      if (p.y < 0)
         return Directions.South;
      return Directions.West;
   }

   public static Point GetNormal (this Directions dir)
   {
      switch (dir)
      {
         case Directions.North:
            return new Point(0, 1);
         case Directions.East:
            return new Point(1, 0);
         case Directions.South:
            return new Point(0, -1);
         default: // Directions.West:
            return new Point(-1, 0);
      }
   }
}


// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/06/08/tactics-rpg-path-finding/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.