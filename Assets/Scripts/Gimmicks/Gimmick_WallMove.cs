using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_WallMove : MonoBehaviour
{
    [SerializeField] private Vector2 movePositionVector = Vector2.zero;
    private Gimmicks_MoveWall_Manager manager;
    private bool touchPlayer = false;
    private void Start()
    {
        manager = this.gameObject.GetComponentInParent<Gimmicks_MoveWall_Manager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!manager.MoveWall) return;
            if (!manager.PlayerTouch)
            {
                var x = collision.gameObject.transform.position.x;
                var y = collision.gameObject.transform.position.y;

                if (movePositionVector.x != 0) x = x * (-1) + movePositionVector.x;
                else if (movePositionVector.y > 0) y = y * (-1) + movePositionVector.y;
                else y = y * (-1);

                collision.gameObject.transform.position = new Vector2(x, y);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (manager.PlayerTouch) manager.PlayerTouch = false;
        }
    }
}
