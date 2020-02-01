using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpChangeScene : MonoBehaviour
{
    IEnumerator GoFinalScreen()
    {
        yield return new WaitForSeconds(5.0f);
        transform.GetComponent<SceneTransitioner>().Transition("FinalScreen");
    }
    void Start()
    {
        StartCoroutine("GoFinalScreen");
    }
}
