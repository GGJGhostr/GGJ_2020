using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ScreenEndUI : MonoBehaviour
{

    [SerializeField] private Text p1_score = null;
    [SerializeField] private Text p2_score = null;

    [SerializeField] private Button m_menu_button = null;


    private void Awake()
    {
        Ghostr.GameManager gm = Ghostr.GameManager.Instance;

        m_menu_button.onClick.AddListener(Ghostr.GameManager.Instance.GoToMenu);
        p1_score.text = gm.ScoringManager.Player1_score.ToString();
        p2_score.text = gm.ScoringManager.Player2_score.ToString();
    }

}
