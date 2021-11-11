using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class WalkMovement : Movement
{
    
    protected override bool ExpandSearch(Tile from, Tile to)
    {
        // Skip if the distance in height between the two tiles is more that the unit can jump
        if (Mathf.Abs(from.height - to.height) > jumpHeight)
        {
            return false;
        }
       
        //Skip if the tile is occupied by an enemy
        if (to.content != null)
        {
            return false;
        }

        return base.ExpandSearch(from, to);
    }
    
    public override IEnumerator Traverse(Tile tile)
    {
        unit.Place(tile);
        
        //Build a list of waypoints from the unit's starting tile to the destination tile
        List<Tile> targets = new List<Tile>();

        while (tile != null)
        {
            targets.Insert(0, tile);
            tile = tile.prev;
        }
        
        //Move to each waypoint in succession
        for (int i = 1; i < targets.Count; i++)
        {
            Tile from = targets[i - 1];
            Tile to = targets[i];

            Directions dir = from.GetDirection(to);

            if (unit.dir != dir)
            {
                yield return StartCoroutine(Turn(dir));
            }
            if (from.height == to.height)
            {
                yield return StartCoroutine(Walk(to));
            }
            else
            {
                yield return StartCoroutine(Jump(to));
            }

            yield return null;
        }

        IEnumerator Walk(Tile to)
        {
            Tweener tweener = transform.MoveTo(target.center, 0.5, EasingEquations.Linear);
            while (tweener != null)
            {
                yield return null;
            }
        }

        IEnumerator Jump(Tile to)
        {
            Tweener tweener = transform.MoveTo(to.center, 0.5f, EasingEquations.Linear);

            Tweener t2 = jumper.MoveToLocal(new Vector3(0, Tile.stepheight * 2f, 0),
                tweener.easingControl.duration / 2f, EasingEquations.EaseOutQuad);
            t2.easingControl.LoopCount = 1;
            t2.easingControl.loopType = easingControl.LoopType.PingPong;

            while (tweener != null)
            {
                yield return null;
            }
        }
    }
}
