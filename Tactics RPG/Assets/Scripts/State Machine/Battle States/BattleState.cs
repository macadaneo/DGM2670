using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BattleState : State
{
    protected BattleController owner;

    public AbilityMenuPanelController AbilityMenuPanelController
    {
        get
        {
            return owner.AbilityMenuPanelController;
        }
    }

    public Turn turn
    {
        get
        {
            return owner.turn;
        }
    }

    public List<Unit> units
    {
        get
        {
            return owner.units;
        }
    }
    public CameraRig cameraRig
    {
        get { return owner.cameraRig; }
    } 
    public Board board
    {
        get { return owner.board;} 
    } 
    public LevelData levelData
    {
        get { return owner.levelData; }
    }
    public Transform tileSelectionIndicator
    {
        get { return owner.tileSelectionIndicator; }
    }
    public Point pos
    {
        get { return owner.pos; }
        set { owner.pos = value; }
    }
    
    protected virtual void Awake()
    {
        owner = GetComponent<BattleController>();
    }

    protected override void AddListeners()
    {
        InputController.moveEvent += OnMove;
            InputController.fireEvent += OnFire;
    }

    protected override void RemoveListeners()
    {
        InputController.moveEvent -= OnMove;
        InputController.fireEvent -= OnFire;
    }

    protected virtual void OnMove(object sender, InfoEventArgs<Point> e)
    {
        
    }

    protected virtual void OnFire(object sender, InfoEventArgs<int> e)
    {
        
    }
   protected virtual void SelectTile(Point p)
    {
        if (pos == p || !board.tiles.ContainsKey(p))
        {
            return;
        }

        pos = p;
        tileSelectionIndicator.localPosition = board.tiles[p].center;
    }
}

// This script comes from a tutorial by Jonathan Parham
// His tutorial can be found here: http://theliquidfire.com/2015/06/01/tactics-rpg-state-machine/
// Further Modification was made by referencing the updated scrips on Jonathan's Repo
// His Repo can be found here: https://bitbucket.org/jparham/blogtacticsrpg/src/master/
// Any additional modification was made most likely at the behest of Rider.