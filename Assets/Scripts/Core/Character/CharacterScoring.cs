using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterScoring : MonoBehaviour
{
    public int Score { get; set; }

    private ScoringManager m_scoringManager = null;

    public UnityEvent m_OnScoreEvent = null;

    [SerializeField] private PlayerSound playerSound;

    private void Awake()
    {
        Score = 0;
        m_OnScoreEvent = new UnityEvent();
        //m_scoringManager = Ghostr.GameManager.Instance.ScoringManager;
    }

    public void incrementScore(int amount = 1)
    {
        playerSound.PlaySound_Hit();
        Score += amount;

        int max_score = SceneScoringHandler.Instance.MAX_SCORE;
        if (Score >= max_score)
            SceneScoringHandler.Instance.CheckForWinner();  

        //m_OnScoreEvent.Invoke();
        //m_scoringManager.CheckScore(this);
    }
}
