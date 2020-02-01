using UnityEngine;
public class PlayersInputs : MonoBehaviour
{
    void CheckPlayerKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Key:K");
        }
    }

    void Update()
    {
        CheckPlayerKeyDown();
    }
}