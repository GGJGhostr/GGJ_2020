using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ghostr
{
    public class SceneHandler : MonoBehaviour
    {

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void ChangeScene(string scene_name)
        {
            SceneManager.LoadScene(scene_name);
            // Change Scene;
        }
    }

}