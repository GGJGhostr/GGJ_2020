using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScoringHandler : MonoBehaviour
{

    private static SceneScoringHandler instance = null;
    public static SceneScoringHandler Instance
    {
        get
        {
            if (instance == null)
                instance = new SceneScoringHandler();
            return instance;
        }
    }

    public CharacterScoring P1_CharacterScoring = null;
    public CharacterScoring P2_CharacterScoring = null;
    [SerializeField] private Loadings loadings = null;

    public int P1_Score { get; private set; }
    public int P2_Score { get; private set; }

    public int MAX_SCORE = 1;

    private void Awake()
    {
        instance = this;      

        P1_CharacterScoring.m_OnScoreEvent.AddListener(CheckForWinner);
        P2_CharacterScoring.m_OnScoreEvent.AddListener(CheckForWinner);

        P1_Score = 0;
        P2_Score = 0;
    }

    public void CheckForWinner()
    {
        P1_Score = 0;
        P2_Score = 0;
        P1_CharacterScoring.Score = 0;
        P2_CharacterScoring.Score = 0;

        loadings.LoadingScene("MainScreen");
        Debug.Log("We have a Winner");

        //if (P1_CharacterScoring.Score >= MAX_SCORE ||
        //    P2_CharacterScoring.Score >= MAX_SCORE)
        //{
        //    /*
        //     * ここで次のシーンをロードします。
        //     * Koko de tsugi no shīn o rōdo shimasu.
        //     */
            
        //}

    }

}
