﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.One;
    public GamePad.PlayerIndex player_idxtwo = GamePad.PlayerIndex.Two;
    [SerializeField] private Loadings loadings;
    private bool loadingStart = false;

    public string scene_name = "MainGame";

    void Update()
    {
        GamepadState player_state = GamePad.GetState(player_idx);
        GamepadState player_statetwo = GamePad.GetState(player_idxtwo);
        if (player_state.A || player_state.B || player_state.X || player_state.Y ||
            player_statetwo.A || player_statetwo.B || player_statetwo.X || player_statetwo.Y || Input.GetKeyDown("space"))
        {
            if (!loadingStart)
            {
                loadings.LoadingScene(scene_name);
                loadingStart = true;
            }
        }
    }
}
