using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LANG_TYPE
{
    English = 0,
    Japanese = 1,
    French = 2,
    Chinese = 3
}

public static class LangConfig
{
    public static LANG_TYPE lang = LANG_TYPE.English;
    public const int MAX_LANG = 4;

    public static string[] START_STR = { "-PRESS ANY BUTTON-", "-任意のボタンを押す-", "-APPUYER SUR UN BOUTON-", "-请按下任意按键-" };
    public static string[] RESTART_STR = { "Restart", "再スタート", "redémarrer" };
    public static string[] TITLE_IMAGE_PATH = { "Texture/title", "Texture/title_jp", "Texture/title", "Texture/title" };
    public static string[] LOADING_IMAGE_PATH = { "Texture/loading_en", "Texture/loading_jp", "Texture/loading_en", "Texture/loading_en" };
    public static string[] BLUE_WIN_IMAGE_PATH = { "Texture/bluewin_en", "Texture/bluewin_jp", "Texture/bluewin_en", "Texture/bluewin_en" };
    public static string[] PINK_WIN_IMAGE_PATH = { "Texture/pinkwin_en", "Texture/pinkwin_jp", "Texture/pinkwin_en", "Texture/pinkwin_en" };
}

public class LangController : MonoBehaviour
{
    void Awake()
    {
        ChangeUIText();
    }
    public Text tex_start;
    public Text tex_restart;
    public Image img_title;
    public Image img_final;
    public Image img_loading;

    private void ChangeUIText()
    {
        if (tex_start != null) tex_start.text = LangConfig.START_STR[(int)LangConfig.lang];
        if (tex_restart != null) tex_restart.text = LangConfig.RESTART_STR[(int)LangConfig.lang];
        if (img_title != null) img_title.sprite = Resources.Load<Sprite>(LangConfig.TITLE_IMAGE_PATH[(int)LangConfig.lang]);

        if (img_loading != null) img_loading.sprite = Resources.Load<Sprite>(LangConfig.LOADING_IMAGE_PATH[(int)LangConfig.lang]);

        if (img_final != null)
        {
            //! game over
            //! get winner
            Character winner = PlayerConfig.winner;
            if (winner.GetPlayerID() == 1)
            {
                img_final.sprite = Resources.Load<Sprite>(LangConfig.BLUE_WIN_IMAGE_PATH[(int)LangConfig.lang]);
            }
            else if (winner.GetPlayerID() == 2)
            {
                img_final.sprite = Resources.Load<Sprite>(LangConfig.PINK_WIN_IMAGE_PATH[(int)LangConfig.lang]);
            }
        }

    }

    public void ChangeLang(int lang_id)
    {
        LangConfig.lang = (LANG_TYPE)(lang_id);
        ChangeUIText();
    }
}
