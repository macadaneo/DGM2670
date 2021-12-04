using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class MoveTargetState : BattleState
{
    private List<Tile> tiles;

    public override void Enter()
    {
        base.Enter();
        Movement mover = owner.currentUnit.GetComponent<Movement>();
        tiles = mover.GetTilesInRange(board);
        board.SelectTiles(tiles);
    }

    public override void Exit()
    {
        base.Exit();
        board.DeSelectTiles(tiles);
        tiles = null;
    }

    protected override void OnMove(object sender, InfoEventArgs<Point> e)
    {
        SelectTile(e.info + pos);
    }

    protected override void OnFire(object sender, InfoEventArgs<int> e)
    {
        if (tiles.Contains(owner.currentTile))
        {
            owner.ChangeState<MoveSequenceState>();
        }
    }
}

// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/06/01/tactics-rpg-state-machine/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.