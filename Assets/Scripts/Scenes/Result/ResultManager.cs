using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class ResultManager : MonoBehaviour
{
    private Loadings loadings;
    private GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.Any;
    private bool changeScene =true;
    // Start is called before the first frame update
    void Start()
    {
        loadings= this.gameObject.GetComponent<Loadings>();
    }

    // Update is called once per frame
    void Update()
    {
        GamepadState player_state = GamePad.GetState(player_idx);
        if (player_state.B || player_state.A | player_state.X | player_state.Y)
        {
            if (changeScene)
            {
                loadings.LoadingScene("MainScreen");
                GameObject obj = GameObject.Find("SceneHandler");
                Destroy(obj);
                changeScene = false;
            }
        }
    }
}
