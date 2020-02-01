using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{

    [SerializeField] public float ScoreToWin { get; private set; }

    Ghostr.GameManager m_gameManager = null;

    public int Player1_score { get; private set; }
    public int Player2_score { get; private set; }

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

    public void RegisterCharacterScore()
    {
        var pad_index = m_gameManager.PlayerManager.m_charactersList[0].player_idx;
        if(pad_index == GamepadInput.GamePad.PlayerIndex.One)
        {
            Player1_score = m_gameManager.PlayerManager.m_charactersList[0].GetComponent<CharacterScoring>().Score;
            Player2_score = m_gameManager.PlayerManager.m_charactersList[1].GetComponent<CharacterScoring>().Score;
        }
        else
        {
            Player1_score = m_gameManager.PlayerManager.m_charactersList[1].GetComponent<CharacterScoring>().Score;
            Player2_score = m_gameManager.PlayerManager.m_charactersList[0].GetComponent<CharacterScoring>().Score;
        }
    }

    public void ResetScore()
    {
        Player1_score = 0;
        Player2_score = 0;
    }
}
