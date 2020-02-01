using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GamepadInput;

public class CharacterMovementB : MonoBehaviour
{

    //public int playerId = 1;
    public GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.One;
    GamepadState playerState;


    public float fallMultiplier = 2.2f;
    public float riseMultiplier = 1.5f;

    Rigidbody2D rb;

    private Vector2 runVector;
    public float groundSpeed;
    public float airDrift;

    private float initialAirSpeed;
    public float airSpeed;
    private float currentAirSpeed;

    private bool facingRight = true;

    public float jumpForce;
    private Vector2 jumpVector;

    private bool isGrounded;
    private bool releasedA;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerState = GamePad.GetState(player_idx);

        if(!releasedA)
        {
            if (!playerState.A)
            {
                releasedA = true;
            }

        }
        ManageVerticalVelocity();

        runVector = CheckMovement(playerState.LeftStickAxis.x);
        

        Run();
        CheckJump();

    }

    void ManageVerticalVelocity()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * rb.gravityScale * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (riseMultiplier - 1) * rb.gravityScale * Time.deltaTime;
        }

    }

    Vector2 CheckMovement(float mvtX)
    {
        if (0.5 > mvtX && mvtX > -0.5) //dead zone in the center of the stick
        {
            mvtX = 0;

        }


        if (mvtX > 0)
        {

            SetFacingRight(true);
            mvtX = 1; // unified run speed, can't walk

        }
        else if (mvtX < 0)
        {

            SetFacingRight(false);
            mvtX = -1;
        }
        else
        {
            mvtX = 0;
        }
        return new Vector2(mvtX, 0);
    }

    public void SetFacingRight(bool fRight)
    {
        facingRight = fRight;
        if (fRight)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);

        }
        else
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);

        }
    }


    public bool getFacingRight()
    {
        return facingRight;
    }

    public void SetInitialAirSpeed(float spd)
    {
        initialAirSpeed = spd;

    }
    void Run()
    {
        if (GetGrounded())
        {
            rb.velocity = new Vector2(groundSpeed * runVector.x, rb.velocity.y);
        }
        else
        {
            currentAirSpeed = Mathf.Lerp(initialAirSpeed, airSpeed * runVector.x, airDrift);
            rb.velocity = new Vector2(currentAirSpeed, rb.velocity.y);
        }


    }


    void CheckJump()
    {
        if (playerState.A)
        {
            if (releasedA)
            {
                releasedA = false;
                if (isGrounded)
                {

                    SetInitialAirSpeed(rb.velocity.x);
                    rb.velocity += jumpForce * Vector2.up;

                }
            }
            
        }
    }


    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
        if (grounded)
        {
            SetInitialAirSpeed(0);
        }

    }

    public bool GetGrounded()
    {
        return isGrounded;
    }

}
