using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Player : MonoBehaviour
{

    CharacterController2D m_controller = null;
    float horizontal_move = 0f;
    public float run_speed = 40f;
    private bool is_jumping = false;
    public GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.One;


    void Start()
    {
        m_controller = GetComponent<CharacterController2D>();

    }


    // Update is called once per frame
    void Update()
    {
        GamepadState player_state = GamePad.GetState(player_idx);

        is_jumping = player_state.A;
        horizontal_move = player_state.LeftStickAxis.x * run_speed;
    }

    private void FixedUpdate()
    {
        m_controller.Move(horizontal_move * Time.deltaTime, false, is_jumping);
        is_jumping = false;
    }
}
