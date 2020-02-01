using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GamepadInput;

public class Character :MonoBehaviour
{
    private Vector2 velocity = new Vector2(0, 0);

    [SerializeField]private float walk = 50.0f;
    [SerializeField] private float baseSpeed = 10f;
    [SerializeField] private float initialTime = 2.0f;
    private float deleteTime = 0;

    [SerializeField] private float jump = 50.0f;
    [SerializeField] private float gravity = 100.0f;
    [SerializeField] private float baseGravity = -50f;
    [SerializeField] private bool terminalGravity = false;
    [SerializeField] private float moveJumpingForce = 0.3f;
    [SerializeField] private bool moveJumping = false;
    private bool jumpTruth = true;

    private Rigidbody2D rigidbody2d;
    private GameObject child;
    private GroundingDecision groundingDecision;

    public InputField input;
    public float smooth = 0.01f;
    public GamePad.PlayerIndex player_idx = GamePad.PlayerIndex.One;

    [SerializeField]private bool changeGrabityUPDOWN = false;

    //action

    //new type
    public void Move(Vector3 vector)
    {
        if (changeGrabityUPDOWN)
        {
            vector = new Vector3(vector.x, vector.y * -1.0f, 0);
            this.gameObject.transform.rotation = new Quaternion(180, 0, 0, 0);
        }
        else if (this.gameObject.transform.rotation.x != 0) this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        rigidbody2d.MovePosition(this.gameObject.transform.position+vector);
    }

    //debug
    private void Start()
    {
        rigidbody2d= this.GetComponent<Rigidbody2D>();
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        child = this.gameObject.transform.GetChild(0).gameObject;
        groundingDecision = this.gameObject.transform.GetChild(0).gameObject.GetComponent<GroundingDecision>();
    }

    private void UpdatePlayerStates()
    {
        if (!groundingDecision.Ground)//Avoid moving while jumping
        {
            var vector = velocity * Time.deltaTime;
            Move(vector);
            if (velocity.y < 0 && !child.activeInHierarchy) child.SetActive(true);
            velocity =(velocity.y < baseGravity && terminalGravity)?velocity: new Vector2(velocity.x, velocity.y - gravity * Time.deltaTime);
            if (!moveJumping) return;
        }
        else if (!child.activeInHierarchy && velocity.y != 0) velocity = Vector2.zero;

        GamepadState player_state = GamePad.GetState(player_idx);
        if (player_state.A && groundingDecision.Ground)//jump
        {
            velocity = new Vector3(velocity.x, velocity.y + jump);
            child.SetActive(false);
            groundingDecision.Ground = false;
            return;
        }
        else if (player_state.LeftStickAxis != Vector2.zero)
        {
            var plus = (player_state.LeftStickAxis.x < 0) ? -1.0f : 1.0f;
            if (!groundingDecision.Ground) plus *= moveJumpingForce;
            velocity = new Vector3(Mathf.Lerp(baseSpeed*plus, walk * plus, deleteTime / initialTime), velocity.y, 0);
            if (initialTime > deleteTime) deleteTime += Time.deltaTime;
            var vector = velocity * Time.deltaTime;
            Move(vector);
            return;
        }
        if (deleteTime != 0)
        {
            deleteTime = 0;
            velocity.x = 0;
        }
    }

    private void FocusOnInput()
    {
        EventSystem.current.SetSelectedGameObject(input.gameObject, null);
    }

    void FixedUpdate()
    {
        //FocusOnInput();
        UpdatePlayerStates();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if(!groundingDecision.Ground)velocity.x = 0;
        }
    }
}
