using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmicks_MoveWall_Manager : MonoBehaviour
{
    private bool playerTouch = false;
    public bool PlayerTouch
    {
        get { return playerTouch; }
        set { playerTouch = value; }
    }
    private bool moveWall = true;
    public bool MoveWall
    {
        get { return moveWall; }
        set { moveWall = value; }
    }
}
