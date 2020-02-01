using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public void Transition(string sceneName)
    {
        Ghostr.GameManager.Instance.StartGame();
        //SceneManager.LoadSceneAsync(sceneName);
    }
}