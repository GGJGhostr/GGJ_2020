using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScoringHandler : MonoBehaviour
{

    public CharacterScoring P1_CharacterScoring = null;
    public CharacterScoring P2_CharacterScoring = null;
    [SerializeField] private Loadings loadings = null;

    public int P1_Score { get; private set; }
    public int P2_Score { get; private set; }

    private int MAX_SCORE = 1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        P1_CharacterScoring.m_OnScoreEvent.AddListener(CheckForWinner);
        P2_CharacterScoring.m_OnScoreEvent.AddListener(CheckForWinner);
    }

    private void CheckForWinner()
    {
        if(P1_CharacterScoring.Score >= MAX_SCORE ||
            P2_CharacterScoring.Score >= MAX_SCORE)
        {
            /*
             * ここで次のシーンをロードします。
             * Koko de tsugi no shīn o rōdo shimasu.
             */
            loadings.LoadingScene("Result");
            Debug.Log("We have a Winner");
        }

    }

}
