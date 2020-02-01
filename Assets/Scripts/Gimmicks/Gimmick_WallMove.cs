using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_WallMove : MonoBehaviour
{
    [SerializeField] private Vector2 movePositionVector = Vector2.zero;
    [SerializeField] private Vector2 charactorSize = new Vector2(0.5f, 1);
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
                var coll = collision.gameObject.transform.position;
                manager.PlayerTouch = true;
                collision.gameObject.transform.position=coll * movePositionVector;
                if(movePositionVector.y!=0&& coll.y>0)
                {
                    collision.gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + charactorSize.y);
                }
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
