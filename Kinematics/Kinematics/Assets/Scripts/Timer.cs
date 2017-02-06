using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public static float predictedTime;

    public MoveBody objectA;
    public MoveBody objectB;

	// Use this for initialization
	void Start () {
        float h = objectA.transform.position.x - objectB.transform.position.x;

        float a = objectB.acceleration - objectA.acceleration;
        float b = 2 * (objectB.initialVelocity - objectA.initialVelocity);
        float c = -2 * h;

        predictedTime = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / ( 2 * a );
        //print("a="+a+" b="+b+" c="+c);
        print(predictedTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
