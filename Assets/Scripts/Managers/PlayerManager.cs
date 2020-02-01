using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private Transform m_player1Spawner = null;
    [SerializeField] private Transform m_player2Spawner = null;

    [SerializeField] private GameObject m_player1Prefab = null;
    [SerializeField] private GameObject m_player2Prefab = null;

    private List<Character> m_charactersList = null;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        m_charactersList = new List<Character>();
    }

    public void RegisterCharacterReference()
    {
        m_charactersList = new List<Character>(FindObjectsOfType<Character>());

        //GameObject obj = Resources.Load("Prefabs/Character") as GameObject;

        //GameObject p1_gao = Instantiate(obj, m_player1Spawner.transform.position, m_player1Spawner.transform.rotation);
        //Character p1 = p1_gao.GetComponent<Character>();
        //p1.player_idx = GamepadInput.GamePad.PlayerIndex.One;

        //GameObject p2_gao = Instantiate(obj, m_player1Spawner.transform.position, m_player2Spawner.transform.rotation);
        //Character p2 = p2_gao.GetComponent<Character>();
        //p2.player_idx = GamepadInput.GamePad.PlayerIndex.Two;


        //m_charactersList.Add(p1);
        //m_charactersList.Add(p2);
    }

    public void ClearPlayer()
    {
        //Destroy(m_charactersList[1].gameObject);
        //Destroy(m_charactersList[0].gameObject);
        //
        //m_charactersList.Clear();
    }

}
