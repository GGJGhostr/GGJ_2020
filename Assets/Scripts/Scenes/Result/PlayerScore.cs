using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private SpriteScriptable spriteScriptable;
    public GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.One;
    [SerializeField] private Image characterImage;
    [SerializeField] private Text scoreText;


    private void Start()
    {
        var character = PlayerPrefs.GetInt(player_idx.ToString(),0);
        //characterImage.sprite = spriteScriptable.sprites[character];
        GameObject obj = GameObject.Find("SceneHandler");
        if (obj == null)
        {
            Debug.Log("Missing SceneHandler");
            return;
        }

        var score = 0.0f;
        if (player_idx == GamePad.PlayerIndex.One) score = obj.GetComponent<SceneScoringHandler>().P1_Score;
        else score = obj.GetComponent<SceneScoringHandler>().P2_Score;

        scoreText.text = "Score :: " + score;
    }
}
