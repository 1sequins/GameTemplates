using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour {

    Rigidbody2D rb;
    float velocity;
    bool isGrounded;

    // Use this for initialization
    void Start () {
        // There will always be a Rigidbody2D
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //rb.MovePosition(rb.position + velocity*Time.fixedDeltaTime);
        rb.velocity = new Vector2(velocity, rb.velocity.y);
	}

    public void MoveBody(float _velocity)
    {
        velocity = _velocity;
    }

    public void jump(float jumpForce)
    {
        if (isGrounded)
        {
            Debug.Log("jumping: " + jumpForce);
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
}
