using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScoring : MonoBehaviour
{
    public int Score { get; private set; }

    private ScoringManager m_scoringManager = null;

    private void Awake()
    {
        m_scoringManager = Ghostr.GameManager.Instance.ScoringManager;
    }

    public void incrementScore(int amount = 1)
    {
        Score += amount;
        m_scoringManager.CheckScore(this);
    }
}
