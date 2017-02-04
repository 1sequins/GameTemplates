using UnityEngine;
using System.Collections;

public class movingBlocks : MonoBehaviour {

    Vector2 startPosition;
    float distance = 5.0f;
    int direction = 1;

    float waitingTime = 2.0f;
    float speed = 1.0f;
    float movingTime = 2.0f;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        StartCoroutine( Move() );
	}

    void Update()
    {
        transform.Translate(Vector2.up * direction * speed * Time.deltaTime, Space.World);
    }

    IEnumerator Move()
    {
        //Debug.Log("waiting...");
        //yield return new WaitForSeconds(waitingTime);
        Debug.Log("moving...");
        
        yield return new WaitForSeconds(movingTime);
        direction *= -1;
        StartCoroutine(Move());
    }

	
}
