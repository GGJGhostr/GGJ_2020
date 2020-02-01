using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUI_Script : MonoBehaviour
{
    [SerializeField] private ScreenEndUI m_screenEndUI = null;

    private OpenCommandMenu m_openCommandMenu = null;
    private Ghostr.GameManager m_gameManager = null;

    private void Awake()
    {
        m_gameManager = Ghostr.GameManager.Instance;
    }

    public void DisplayEndScreen()
    {
        m_openCommandMenu.enabled = false;
        m_screenEndUI.gameObject.SetActive(true);


        
    }

}
