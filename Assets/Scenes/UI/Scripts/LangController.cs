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
    public static string[] TITLE_IMAGE_PATH = { "Textures/title", "Textures/title_jp" };
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

    private void ChangeUIText()
    {
        if (tex_start != null) tex_start.text = LangConfig.START_STR[(int)LangConfig.lang];
        if (tex_restart != null) tex_restart.text = LangConfig.RESTART_STR[(int)LangConfig.lang];
        //if (img_title != null) img_title.Image = Resources.Load<Image>(LangConfig.TITLE_IMAGE_PATH[(int)LangConfig.lang]);

    }

    public void ChangeLang(int lang_id)
    {
        LangConfig.lang = (LANG_TYPE)(lang_id);
        ChangeUIText();
    }
}
