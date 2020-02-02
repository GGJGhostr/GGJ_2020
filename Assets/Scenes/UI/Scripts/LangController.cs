using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LANG_TYPE
{
    English = 0,
    Japanese = 1,
    French = 2
}

public static class LangConfig
{
    public static LANG_TYPE lang = LANG_TYPE.English;
    public const int MAX_LANG = 3;

    public static string[] START_STR = { "Start", "スタート", "début" };
    public static string[] RESTART_STR = { "Restart", "再スタート", "redémarrer" };
    public static string[] LANG_STR = { "Lang", "言語", "langue" };
}

public class LangController : MonoBehaviour
{
    void Awake()
    {
        ChangeUIText();
    }
    public Text tex_start;
    public Text tex_lang;
    public Text tex_restart;
    private void ChangeUIText()
    {
        if (tex_start != null) tex_start.text = LangConfig.START_STR[(int)LangConfig.lang];
        if (tex_lang != null) tex_lang.text = LangConfig.LANG_STR[(int)LangConfig.lang];
        if (tex_restart != null) tex_restart.text = LangConfig.RESTART_STR[(int)LangConfig.lang];
    }

    public void ChangeLang()
    {
        LangConfig.lang = (LANG_TYPE)(((int)LangConfig.lang + 1) % LangConfig.MAX_LANG);
        ChangeUIText();
    }
}
