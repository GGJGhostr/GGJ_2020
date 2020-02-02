using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class Loadings : MonoBehaviour
{
   public static string nextSceneName = null;

    void Start()
    {
        Scene scene = SceneManager.GetSceneAt(0);
        if (scene.name == "Loading") SceneManager.UnloadSceneAsync("Loading");
    }

    public void LoadingScene(string nextName)
    {
        nextSceneName = nextName;
        SceneManager.LoadScene("Loading"/*, LoadSceneMode.Additive*/);
    }

}  
 