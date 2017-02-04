using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    Transform initialCameraPosition, player;

	// Use this for initialization
	void Awake () {
        //initialCameraPosition = gameObject.transform;
        //initialCameraPosition.position = new Vector2(1.04f, 0.52f);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 camPos = gameObject.transform.position;
        //Debug.Log("Initial camera X position: "+ initialCameraPosition.position.x+" Player X position: "+player.position.x);
        camPos.x = Mathf.Max(initialCameraPosition.position.x, player.position.x);
        //camPos.x = Mathf.Max(1.04f, player.position.x);
        gameObject.transform.position = camPos;
	}
}
