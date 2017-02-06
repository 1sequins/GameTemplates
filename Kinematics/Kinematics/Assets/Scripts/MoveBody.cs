using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBody : MonoBehaviour {

    [Header("Movement")]

    public float initialVelocity, acceleration;
    float time;

    float currentVelocity;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        time = 0.0f;
        currentVelocity = initialVelocity;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        time += Time.fixedDeltaTime;
        if (Time.fixedTime < Timer.predictedTime)
        {
            //currentVelocity = initialVelocity + (acceleration * time);
            currentVelocity += (acceleration * Time.fixedDeltaTime );
            rb.velocity = new Vector2(currentVelocity, 0f);
        } else
        {
            rb.velocity = Vector2.zero;
        }
	}

    public float getInitialVelocity()
    {
        return initialVelocity;
    }

    public float getAcceleration()
    {
        return acceleration;
    }

    public float getCurrentVelocity()
    {
        return currentVelocity;
    }
}
