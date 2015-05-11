using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 10f;
    public Vector2 maxVelocity = new Vector2(3, 5);
    public bool grounded = false;
    public float jumpSpeed = 5f;
    public float jumpHeight;
    public float airSpeedMultiplier = .3f;

    private Animator anim;
    private PlayerController controller;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        var forceX = 0f;
        var forceY = 0f;
        var rb = GetComponent<Rigidbody2D>();


        var absVelX = Mathf.Abs (rb.velocity.x);
        var absVelY = Mathf.Abs(rb.velocity.y);

        if (absVelY < .2f)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
 /*
        if (Input.GetKey("right"))
        {
            if (absVelX < maxVelocity.x)
                forceX = grounded ? speed : (speed * airSpeedMultiplier);

            transform.localScale = new Vector3(1, 1, 1);

            anim.SetInteger("AnimState", 1);
        }
        else if (Input.GetKey("left"))
        {
            if (absVelX < maxVelocity.x)
                forceX = grounded ? -speed : (-speed * airSpeedMultiplier);
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetInteger("AnimState", 1);
        }
        else
        {
            anim.SetInteger("AnimState", 0);
        } */

        if (controller.moving.x != 0)
        {
            if (absVelX < maxVelocity.x)
            {
                forceX = grounded ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);
                transform.localScale = new Vector3(forceX < 0 ? -1 : 1, 1, 1);
            }
            anim.SetInteger("AnimState", 1);
        }
        else 
        {
            anim.SetInteger("AnimState", 0);
        }
        
        if (controller.moving.y < 0)
        {
            if (absVelY < maxVelocity.y)
            {
                forceY = jumpSpeed * controller.moving.y; 
            }
            
        }
        

        
        if (Input.GetKeyDown("space") && grounded == true)
        {
            if (absVelY < maxVelocity.y)
            {
                rb.velocity = new Vector2(rb.position.x, jumpHeight);  
            }
            anim.SetInteger("AnimState", 2);
        } 


        rb.AddForce(new Vector2(forceX, forceY));
	}
}
