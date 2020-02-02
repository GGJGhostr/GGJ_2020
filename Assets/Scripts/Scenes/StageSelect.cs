using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageSelect : MonoBehaviour
{
    [SerializeField] private List<CharacterSelectManager> characterSelects = new List<CharacterSelectManager>();
    private bool stageSelect = false;

    public GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.Any;

    [SerializeField] private Text stagename;
    [SerializeField] private StringScriptable strings;
    private bool select = false;
    private int selectStageNumber = 0;

    [SerializeField] private Loadings loadings;
    private bool loadingStart = false;

    // Start is called before the first frame update
    void Start()
    {
        stagename.text = strings.strings[selectStageNumber];
    }

    // Update is called once per frame
    void Update()
    {
        GamepadState player_state = GamePad.GetState(player_idx);
        if (stageSelect)
        {
            StageSelectUpdatte();
            return;
        }
        var notChanged = false;
        foreach (CharacterSelectManager character in characterSelects)
        {
            if (!character.EndSelect) notChanged = true;
        }
        if (!notChanged) if (!player_state.B )stageSelect = true;
    }

    private void StageSelectUpdatte()
    {
        GamepadState player_state = GamePad.GetState(player_idx);

        if (player_state.B)
        {
            LoadBattleStage(strings.strings[selectStageNumber]);
        }
        else if (player_state.LeftStickAxis.x != 0)
        {
            if(player_state.LeftStickAxis.x != 0) selectStageNumber += (player_state.LeftStickAxis.x > 0) ? 1 : -1;

            if (selectStageNumber < 0) selectStageNumber = strings.strings.Length-1;
            else if (selectStageNumber >= strings.strings.Length) selectStageNumber = 0;
            stagename.text = strings.strings[selectStageNumber];
            select = false;
            return;
        }
        if (player_state.LeftStickAxis.x == 0 ) select = true;

    }
    private void LoadBattleStage(string name)
    {
        if (string.IsNullOrEmpty(name)) return;
        //SceneManager.LoadScene(name);
        if (!loadingStart)
        {
            loadings.LoadingScene(name);
            loadingStart = true;
        }
    }
}
