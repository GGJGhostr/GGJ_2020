using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundingDecision : MonoBehaviour
{
    private bool ground = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {

        }
    }
}