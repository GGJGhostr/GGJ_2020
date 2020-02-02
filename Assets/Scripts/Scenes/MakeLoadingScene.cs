using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MakeLoadingScene : MonoBehaviour
{
    private string nextName = null;
    void Start()
    {
        nextName = Loadings.nextSceneName;
        int sceneCount = SceneManager.sceneCount;
        for (int i = 0; i < sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != "Loading") SceneManager.UnloadSceneAsync(scene.name);
        }
        StartCoroutine(LoadSceneAndWait());
    }

    IEnumerator LoadSceneAndWait()
    {
        AsyncOperation ope = SceneManager.LoadSceneAsync(nextName, LoadSceneMode.Additive);
        ope.allowSceneActivation = false;
        yield return ope.isDone;
        yield return new WaitForSeconds(1.0f);
        ope.allowSceneActivation = true;
    }
}
