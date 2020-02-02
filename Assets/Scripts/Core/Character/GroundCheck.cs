using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer;
    public GameObject player;

    private CharacterMovementB charScript;

    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        charScript = player.GetComponent<CharacterMovementB>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (groundLayer == (groundLayer | (1 << other.gameObject.layer)) && isGrounded == false)
        {

            isGrounded = true;
            charScript.SetGrounded(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (groundLayer == (groundLayer | (1 << other.gameObject.layer)) && isGrounded == true)
        {
            isGrounded = false;
            charScript.SetGrounded(false);
        }
    }
}
