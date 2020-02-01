using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character :MonoBehaviour
{
    #region old parameter
    //character parameter
    private int lifePoint;//life
    private float walkSpeed=50.0f;//walking speed
    private float runSpeed;//run speed //unused?
    private float jumpForce = 500.0f;//jump strength/force
    private float mass;//character weight //unused?
    //private Rigidbody2D rigidbody2d;//rigidbody //unused?

    //unused? parameter 
    //private bool jumpTruth=false;//jumping Judgment
    private float jumpPulsRanPower = 0.0f;// junmping + ranSpeed * jumpPulsRanPower
    //private float initialtime;//initial speed time


    //bullet parameter??
    private Vector2 shootDirection;//shoot direction
    private Vector2 shootStrength;//shoot strength

    #endregion old parameter

    //new type parameter 
    private Vector2 velocity = new Vector2(0, 0);

    private float walk = 5.0f;
    private float initialTime = 2.0f;
    private float deleteTime = 0;

    private float jump = 5.0f;
    private float gravity = 10.0f;
    private bool jumpTruth = false;

    private Rigidbody2D rigidbody2d;

    //action

    //new type
    public void Move(Vector3 vector)
    {
        rigidbody2d.MovePosition(this.gameObject.transform.position+vector);
    }

    #region old action
    public void CharacterMove(Vector2 vector)//move walk or move walk and run
    {
        rigidbody2d.AddForce(vector);
    }

    public void CharacterJump(Vector2 vector)//jump
    {
        rigidbody2d.AddForce(vector);
        jumpTruth = true;
    }

    public void HitBullet(int damage)//received damage or hit bullet
    {
        lifePoint -= damage;
        if (lifePoint <= 0) CharacterDeath();
    }
    private void CharacterDeath()//character life 0
    {
        Debug.Log("character life 0 , character death");
    }

    public void ShootBullet()//shoot bullet
    {
        //create bullet
        //bullet.rigidbody2d.addforce(shootStrength);
        //bullet.direction.change
    }
    #endregion old action

    //debug
    private void Start()
    {
        rigidbody2d= this.GetComponent<Rigidbody2D>();
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void FixedUpdate()
    {
        if (jumpTruth)//Avoid moving while jumping
        {
            var vector = velocity * Time.deltaTime;
            Move(vector);
            if (velocity.y > -jump) 
            {
                velocity =new Vector2(velocity.x,velocity.y -gravity * Time.deltaTime);
                return;
            }
            Debug.Log("move ok");
            velocity = Vector2.zero;
            jumpTruth = false;
            return;
        }
        if ((Input.GetKeyDown(KeyCode.Space))&&!jumpTruth)//jump
        {
            velocity = new Vector3(velocity.x, velocity.y + jump);
            jumpTruth = true;
            return;
        }
        else if (Input.GetKey(KeyCode.RightArrow))//move right
        {
            velocity = new Vector3(Mathf.Lerp(0, walk, deleteTime/initialTime), velocity.y ,0);
            if(initialTime>deleteTime)deleteTime += Time.deltaTime;
            var vector = velocity * Time.deltaTime;
            Move(vector);
            return;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))//move left
        {
            velocity = new Vector3(Mathf.Lerp(0, -walk, deleteTime / initialTime), velocity.y, 0);
            if (initialTime > deleteTime) deleteTime += Time.deltaTime;
            var vector = velocity * Time.deltaTime;
            Move(vector);
            return;
        }
        if(deleteTime!=0)deleteTime = 0;
    }

    //private void FixedUpdate()
    //{

    //    if (jumpTruth)//Avoid moving while jumping
    //    {
    //        if (rigidbody2d.velocity.y == 0)
    //        {
    //            Debug.Log("move ok");
    //            jumpTruth = false;
    //        }
    //        return;
    //    }

    //    if (Input.GetKeyDown(KeyCode.Space))//jump
    //    {
    //        var vector = new Vector2(rigidbody2d.velocity.x, jumpForce);
    //        CharacterJump(vector);
    //        Debug.Log("jump");
    //    }
    //    else if (Input.GetKey(KeyCode.RightArrow))//move right
    //    {
    //        if (rigidbody2d.velocity.x > 5) return;
    //        var vector = new Vector2(walkSpeed, rigidbody2d.velocity.y);
    //        CharacterMove(vector);
    //    }
    //    else if (Input.GetKey(KeyCode.LeftArrow))//move left
    //    {
    //        if (rigidbody2d.velocity.x < -5) return;
    //        var vector = new Vector2(-walkSpeed, rigidbody2d.velocity.y);
    //        CharacterMove(vector);
    //    }
    //}
}
