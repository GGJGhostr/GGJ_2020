using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterScoring : MonoBehaviour
{
    public int Score { get; private set; }

    private ScoringManager m_scoringManager = null;

    public UnityEvent m_OnScoreEvent = null;

    private void Awake()
    {
        Score = 0;
        m_OnScoreEvent = new UnityEvent();
        //m_scoringManager = Ghostr.GameManager.Instance.ScoringManager;
    }

    public void incrementScore(int amount = 1)
    {
        Score += amount;
        m_OnScoreEvent.Invoke();
        //m_scoringManager.CheckScore(this);
    }
}
