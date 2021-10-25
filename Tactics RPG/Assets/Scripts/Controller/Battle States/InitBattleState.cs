using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class InitBattleState : MonoBehaviour
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(InitBattleState());
    }

    IEnumerator Init()
    {
        board.Load(LevelData);
        Point p = new Point((int)levelData.tiles[0].x, (int)levelData.tiles[0].z);
        SelectTile(p);
        yield return null;
        UnknownWrapper.ChangeState<MoveTargetState>();
        
    }
}
