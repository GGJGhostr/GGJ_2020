using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GamepadInput;

public class Character :MonoBehaviour
{
    private Vector2 velocity = new Vector2(0, 0);

    [SerializeField]private float walk = 50.0f;
    [SerializeField] private float initialTime = 2.0f;
    private float deleteTime = 0;

    [SerializeField] private float jump = 50.0f;
    [SerializeField] private float gravity = 100.0f;
    private bool jumpTruth = false;

    private Rigidbody2D rigidbody2d;

    public InputField input;
    public float smooth = 0.01f;
    public GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.One;

    //action

    //new type
    public void Move(Vector3 vector)
    {
        rigidbody2d.MovePosition(this.gameObject.transform.position+vector);
    }

    //debug
    private void Start()
    {
        rigidbody2d= this.GetComponent<Rigidbody2D>();
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void UpdatePlayerStates()
    {
        if (jumpTruth)//Avoid moving while jumping
        {
            var vector = velocity * Time.deltaTime;
            Move(vector);
            if (velocity.y > -jump) 
            {
                velocity =new Vector2(velocity.x,velocity.y -gravity * Time.deltaTime);
                return;
            }
            Debug.Log("move ok");
            velocity = Vector2.zero;
            jumpTruth = false;
            return;
        }

        GamepadState player_state = GamePad.GetState(player_idx);
        if (player_state.A && !jumpTruth)//jump
        {
            velocity = new Vector3(velocity.x, velocity.y + jump);
            jumpTruth = true;
            return;
        }
        else if (player_state.LeftStickAxis != Vector2.zero)
        {
            var puls = (player_state.LeftStickAxis.x < 0) ? -1 : 1;
            velocity = new Vector3(Mathf.Lerp(0, walk * puls, deleteTime / initialTime), velocity.y, 0);
            if (initialTime > deleteTime) deleteTime += Time.deltaTime;
            var vector = velocity * Time.deltaTime;
            Move(vector);
            return;
        }
        if(deleteTime!=0)deleteTime = 0;
    }

    private void FocusOnInput()
    {
        EventSystem.current.SetSelectedGameObject(input.gameObject, null);
    }

    void Update()
    {
        FocusOnInput();
        UpdatePlayerStates();
    }
}
