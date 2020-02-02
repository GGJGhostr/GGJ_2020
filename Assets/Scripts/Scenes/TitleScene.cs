using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    private GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.Any;
    [SerializeField] private Loadings loadings;
    private bool loadingStart=false;
    
    void Update()
    {
        GamepadState player_state = GamePad.GetState(player_idx);
        if (player_state.A || player_state.B || player_state.X || player_state.Y )
        {
            //SceneManager.LoadScene("CharacterSelect");
            if (!loadingStart)
            {
                loadings.LoadingScene("CharacterSelect");
                loadingStart = true;
            }
        }
    }
}
