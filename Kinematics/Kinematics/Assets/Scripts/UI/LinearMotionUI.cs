using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LinearMotionUI : MonoBehaviour {

    [SerializeField]
    Text Header, Footer, objectBProps, objectAProps;

    [SerializeField]
    GameObject objectB, objectA;

    float timeElapsed;

    MoveBody objA, objB;
    // Use this for initialization
    void Start () {
        Header.text = "Predicted Meeting Time (sec): "+Timer.predictedTime.ToString() ;

        objA = objectA.GetComponent<MoveBody>();
        objB = objectB.GetComponent<MoveBody>();

        objectAProps.text = " <b> Red Body </b> \n Initial Velocity: " + objA.getInitialVelocity().ToString("F2") + "\nAcceleration: " + objA.getAcceleration().ToString("F2") + "\n Current Velocity: " + objA.getCurrentVelocity().ToString("F2");
        objectBProps.text = " <b> Blue Body </b> \n Initial Velocity: " + objB.getInitialVelocity().ToString("F2") + "\nAcceleration: " + objB.getAcceleration().ToString("F2") + "\n Current Velocity: " + objB.getCurrentVelocity().ToString("F2");

        timeElapsed = 0.0f;
        Time.fixedDeltaTime = 0.001f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.fixedTime <= Timer.predictedTime)
        {
            Footer.text = "Distance between bodies: "+(Mathf.Abs(objectA.transform.position.x - objectB.transform.position.x)).ToString("F2")+" units\n"+ "Time elapsed: " + Time.fixedTime.ToString()+" sec";
            objectAProps.text = " <b> Red Body </b> \n Initial Velocity: " + objA.getInitialVelocity().ToString("F2") + " unit/s\nAcceleration: " + objA.getAcceleration().ToString("F2") + " unit/s^2\n Current Velocity: " + objA.getCurrentVelocity().ToString("F2")+" unit/s";
            objectBProps.text = " <b> Blue Body </b> \n Initial Velocity: " + objB.getInitialVelocity().ToString("F2") + " unit/s\nAcceleration: " + objB.getAcceleration().ToString("F2") + " unit/s^2\n Current Velocity: " + objB.getCurrentVelocity().ToString("F2") +" unit/s";
        }
	}
}
