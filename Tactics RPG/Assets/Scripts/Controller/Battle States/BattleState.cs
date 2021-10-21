using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : State
{
    protected BattleController owner;
    /*public CamerRig cameraRig
    {
        get { return owner.board; }
    }
    public Board board
    {
        get { return owner.levelData; }
    }*/
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
}
