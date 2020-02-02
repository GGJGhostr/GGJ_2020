using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Character : MonoBehaviour, IHackable
{
    private int player_id;
    private SpriteRenderer m_spriteRenderer = null;
    private CharacterScoring m_scoring = null;

    float horizontal_move = 0f;
    //public float run_speed = 40f;
    private bool is_jumping = false;

    private bool m_timerNeedUpdate = false;
    private float m_shootTimer = 1f;
    private float m_currentTime = 0f;

    private CharacterShooting m_shootingBehavior = null;
    private bool has_shooted = false;

    private CharacterMovementB m_movement = null;
    private Character_Data cData = null;

    public int GetPlayerID()
    {
        return player_id;
    }
    private void Awake()
    {
        //! edit by Wang
        PlayerConfig.player_cnt++;
        player_id = PlayerConfig.player_cnt;

        m_spriteRenderer = GetComponent<SpriteRenderer>();

        m_shootingBehavior = GetComponent<CharacterShooting>();
        m_scoring = GetComponent<CharacterScoring>();
        m_movement = GetComponent<CharacterMovementB>();
    }

    private void Start()
    {
        cData = GameDataManager.Instance.CharacterData;
        m_spriteRenderer.enabled = cData.uVisible;
        m_movement.groundSpeed = cData.uSpeed;
    }

    void Update()
    {
        if (m_timerNeedUpdate)
            UpdateTimer();

        GamepadState player_state = GamePad.GetState(m_movement.player_idx);
        ComputeCharacterInputAction(player_state);
    }

    public void ComputeHackFromString(string data, dynamic value)
    {
        switch (data)
        {
            case "visible":
                if (value == null)
                    m_spriteRenderer.enabled = !m_spriteRenderer.enabled;
                else
                    m_spriteRenderer.enabled = value;

                cData.uVisible = m_spriteRenderer.enabled;
                break;

            case "speed":
                m_movement.groundSpeed = value;
                cData.uSpeed = value;
                break;

            default:
                break;
        }
    }

    private void UpdateTimer()
    {
        m_currentTime += Time.deltaTime;
        if (m_currentTime >= m_shootTimer)
        {
            m_timerNeedUpdate = false;
            m_currentTime = 0f;
            has_shooted = false;
        }
    }

    private void ComputeCharacterInputAction(GamepadState player_state)
    {
        if (player_state.RightTrigger > 0f && !has_shooted)
        {
            has_shooted = true;
            m_timerNeedUpdate = true;
            m_shootingBehavior.ShootBullet(player_state.rightStickAxis);
        }
    }

}
