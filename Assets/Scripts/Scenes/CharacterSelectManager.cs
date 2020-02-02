using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
using UnityEngine.UI;

public class CharacterSelectManager : MonoBehaviour
{
    [SerializeField] private SpriteScriptable sprites;
    public GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.One;

    private Image characterImage;
    private int selectNumber = 0;
    private bool changed = false;
    private float time = 0;
    private float delay = 0.3f;
    private bool endSelect = false;
    public bool EndSelect => endSelect;

    private void Start()
    {
        characterImage = this.gameObject.GetComponent<Image>();
        characterImage.sprite= sprites.sprites[selectNumber];
    }

    private void Update()
    {
        if (endSelect) return;
        GamepadState player_state = GamePad.GetState(player_idx);

        if (player_state.B)
        {
            PlayerPrefs.GetInt(player_idx.ToString(), selectNumber);
            PlayerPrefs.Save();
            endSelect = true;
        }
        else if (player_state.LeftStickAxis.x != 0&&!changed)
        {
            selectNumber += (player_state.LeftStickAxis.x > 0) ? 1 : -1;
            if (selectNumber < 0) selectNumber = sprites.sprites.Length - 1;
            else if (selectNumber >= sprites.sprites.Length) selectNumber = 0;
            characterImage.sprite = sprites.sprites[selectNumber];
            Debug.Log(selectNumber);
            changed = true;
            return;
        }
        if (player_state.LeftStickAxis.x== 0) changed = false;
    }
}
