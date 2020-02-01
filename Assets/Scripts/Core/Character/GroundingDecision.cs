using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundingDecision : MonoBehaviour
{
    private bool ground = false;
    public bool Ground
    {
        get { return ground; }
        set { ground = value; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (!ground)
            {
                ground = true;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (ground)
            {
                ground = false;
            }

        }
    }
}