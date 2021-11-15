using UnityEngine;
using System.Collections;
public class BattleController : StateMachine 
{
    public CameraRig cameraRig;
    public Board board;
    public LevelData levelData;
    public Transform tileSelectionIndicator;
    public Point pos;

    public GameObject heroPrefab;
    public Unit currentUnit;
    public Tile currentTile
    {
        get
        {
            return board.GetTile(pos);
        }
    }
    void Start ()
    {
       ChangeState<InitBattleState>();
    }
}

// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/06/01/tactics-rpg-state-machine/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.