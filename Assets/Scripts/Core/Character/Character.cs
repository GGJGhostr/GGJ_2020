using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Character : MonoBehaviour
{
    CharacterController2D m_controller = null;
    float horizontal_move = 0f;
    public float run_speed = 40f;
    private bool is_jumping = false;
    public GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.One;

    private bool m_timerNeedUpdate = false;
    private float m_shootTimer = 1f;
    private float m_currentTime = 0f;

    private CharacterShooting m_shootingBehavior = null;
    private bool has_shooted = false;

    private void Awake()
    {
        m_controller = GetComponent<CharacterController2D>();
        m_shootingBehavior = GetComponent <CharacterShooting>();
    }

    void Update()
    {
        if (m_timerNeedUpdate)
            UpdateTimer();

        GamepadState player_state = GamePad.GetState(player_idx);
        ComputeCharacterInputAction(player_state);
        horizontal_move = player_state.LeftStickAxis.x * run_speed;
    }

    private void UpdateTimer()
    {
        m_currentTime += Time.deltaTime;
        if(m_currentTime >= m_shootTimer)
        {
            m_timerNeedUpdate = false;
            m_currentTime = 0f;
            has_shooted = false;
        }
    }

    private void ComputeCharacterInputAction(GamepadState player_state)
    {
        is_jumping = player_state.A;

        if (player_state.B && !has_shooted)
        {
            has_shooted = true;
            m_timerNeedUpdate = true;
            m_shootingBehavior.ShootBullet(player_state.rightStickAxis);
        }
    }

    private void FixedUpdate()
    {
        m_controller.Move(horizontal_move * Time.deltaTime, false, is_jumping);
        is_jumping = false;
    }
}
