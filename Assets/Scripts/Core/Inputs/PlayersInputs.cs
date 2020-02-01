//Author: Xu Wang
//Latest Update: Xu Wang

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GamepadInput;


public class PlayersInputs : MonoBehaviour
{
    public InputField input;
    public float smooth = 0.01f;
    public GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.One;

    private bool b_inv_x = false;
    private bool b_inv_y = false;
    private int x_dir = 1;
    private int y_dir = 1;

    void Awake()
    {
        if ((int)player_idx > PlayerConfig.PLAYER_NUM)
        {
            Debug.Log("player index is not correct, the player number is: " + PlayerConfig.PLAYER_NUM);
        }
        else
        {
            Debug.Log("current player index is:" + (int)player_idx);
        }
    }


    private void UpdatePlayerStates()
    {
        GamepadState player_state = GamePad.GetState(player_idx);

        if (player_state.A)
        {
            //Debug.Log("Press A");
            b_inv_x = !b_inv_x;
            if (b_inv_x) x_dir = -1; else x_dir = 1;
        }

        if (player_state.B)
        {
            //Debug.Log("Press B");
            b_inv_y = !b_inv_y;
            if (b_inv_y) y_dir = -1; else y_dir = 1;
        }

        if (player_state.LeftStickAxis!=Vector2.zero)
        {
            //Debug.Log("left Stick:"+ _state.LeftStickAxis);
            transform.position += new Vector3(player_state.LeftStickAxis.x* smooth* x_dir, player_state.LeftStickAxis.y* smooth* y_dir, 0.0f);
        }

        if (player_state.rightStickAxis != Vector2.zero)
        {
            //Debug.Log("right Stick:" + _state.rightStickAxis);
        }
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