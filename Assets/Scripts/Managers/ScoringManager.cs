using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{

    [SerializeField] public float ScoreToWin { get; private set; }

    Ghostr.GameManager m_gameManager = null;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        m_gameManager = Ghostr.GameManager.Instance;
        ScoreToWin = 1;
    }

    public void CheckScore(CharacterScoring scoringCharacter)
    {
        if (scoringCharacter.Score >= ScoreToWin)
            m_gameManager.OnWin(scoringCharacter.GetComponent<Character>());
    }
}
