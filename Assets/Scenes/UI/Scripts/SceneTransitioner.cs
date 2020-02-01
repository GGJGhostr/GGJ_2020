using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public void Transition(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}